using WeatherLogger.Helpers;
using WeatherLogger.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    ProcessLogger.Configure(builder.Configuration);
    builder.Services.AddHostedService<DailyWeatherLoger>();
    builder.Services.AddControllers();

    var app = builder.Build();

    app.MapControllers();
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine("Main Error Message:" + e);
    throw;
}