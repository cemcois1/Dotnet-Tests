using System.Text.Json;
using WeatherLogger.Helpers;
using WeatherLogger.Models;

namespace WeatherLogger.Services;

public interface IDailyWeatherLoger
{
    public Task LogDailyWeather();
}

public class DailyWeatherLoger : BackgroundService, IDailyWeatherLoger
{
    public readonly string RequestURL;

    public DailyWeatherLoger(IConfiguration configuration)
    {
        try
        {
            var _lat = configuration.GetSection("WeatherLogger:Lat").Get<double>();
            var _lon = configuration.GetSection("WeatherLogger:Lon").Get<double>();
            var ApiKey = configuration.GetSection("WeatherLogger:APIKey").Get<string>();
            RequestURL = string.Format(configuration.GetSection("WeatherLogger:URL").Get<string>(), _lat, _lon, ApiKey);
            ProcessLogger.Log("Daily Weather Config Load Edildi: " + RequestURL);
        }
        catch (Exception e)
        {
            ProcessLogger.Error(" Daily Weather Config Load Hatası" + e);
            throw;
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //test için her dakika çalışsın
        while (!stoppingToken.IsCancellationRequested)
        {
            await LogDailyWeather();
            await Task.Delay(60000 * 60 * 24, stoppingToken);
        }

        //get data from weather api
        //log data to a file
    }

    public async Task LogDailyWeather()
    {
        try
        {
            //get data from weather api
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(RequestURL);
            if (response.IsSuccessStatusCode)
            {
                ProcessLogger.Log("Hava Durumu Loglama alındı");
                var content = await response.Content.ReadAsStringAsync();
                var weaterData = JsonSerializer.Deserialize<RawWeatherData>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                ProcessLogger.Log("Hava Durumu Serialize edildi");


                var HeatCelcius = weaterData.Main.Temp - 273.15;
                var WeatherMain = weaterData.Weather[0].Main;
                var WindRoute = weaterData.Wind.Deg;
                var WindSpeed = weaterData.Wind.Speed;

                var RuzgarYonuText = WindRoute switch
                {
                    >= 0 and < 45 => "Kuzey",
                    >= 45 and < 90 => "Kuzey Doğu",
                    >= 90 and < 135 => "Doğu",
                    >= 135 and < 180 => "Güney Doğu",
                    >= 180 and < 225 => "Güney",
                    >= 225 and < 270 => "Güney Batı",
                    >= 270 and < 315 => "Batı",
                    >= 315 and < 360 => "Kuzey Batı",
                    _ => "Bilinmiyor"
                };
                var turkceContent =
                    $"Sıcaklık: {HeatCelcius} Hava Durumu: {WeatherMain} Rüzgar Yönü: {RuzgarYonuText} Rüzgar Hızı: {WindSpeed}";

                ProcessLogger.Log("Hava Durumu degerler turkcelestirildi");

                //log data to a file
                using (StreamWriter writer = new StreamWriter("weatherlog.txt", true))
                {
                    writer.WriteLine($"Tarih :{DateTime.Now} Hava durumu: {turkceContent}");
                }

                ProcessLogger.Log("Hava Durumu degerler kaydedildi");
            }

            ProcessLogger.Log("Hava Durumu Loglama alındı");
        }
        catch (Exception e)
        {
            ProcessLogger.Log("Daily Weater Loglama Hatası" + e);
            throw;
        }
    }
}