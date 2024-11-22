using System.Text;
using SoapCore;
using WeatherLogger.Helpers;
using WeatherLogger.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    ProcessLogger.Configure(builder.Configuration);
    builder.Services.AddSingleton<DailyWeatherSoapService>();
    builder.Services.AddHostedService<DailyWeatherLoger>();

    // SoapCore'un hata dönüşümlerini işlemek için varsayılan bir transformer kaydedin
    builder.Services.AddSoapCore();
    builder.Services.AddControllers();
    
    var app = builder.Build();

    app.UseSoapEndpoint<DailyWeatherSoapService>("/WeatherLogger.svc", new SoapEncoderOptions(),caseInsensitivePath:true);

    app.MapControllers();
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine("Main Error Message:" + e);
    throw;
}