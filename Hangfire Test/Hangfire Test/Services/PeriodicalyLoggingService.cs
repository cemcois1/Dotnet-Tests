using Hangfire_Test.Controllers;
using Hangfire;

namespace Hangfire_Test.Services;

public class PeriodicalyLoggingService: BackgroundService
{
    private WeatherForecastController _weatherForecastController;
    // Constructor ile bağımlılığı alıyoruz
    public PeriodicalyLoggingService(WeatherForecastController weatherForecastController)
    {
        _weatherForecastController = weatherForecastController ?? throw new ArgumentNullException(nameof(weatherForecastController));
        Console.WriteLine("Periodicaly Logging Service created");
    }
    
    protected override  Task ExecuteAsync(CancellationToken stoppingToken)
    {
        BackgroundJob.Schedule(()=>_weatherForecastController.GetData(),TimeSpan.FromSeconds(10));
        RecurringJob.AddOrUpdate("GetData", () => _weatherForecastController.GetData(), Cron.Minutely);
        return Task.CompletedTask;
    }
}