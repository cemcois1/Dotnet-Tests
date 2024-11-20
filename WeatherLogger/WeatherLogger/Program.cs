using WeatherLogger.Helpers;
using WeatherLogger.Services;

var builder = WebApplication.CreateBuilder(args);

ProcessLogger.Configure(builder.Configuration);
builder.Services.AddHostedService<DailyWeatherLoger>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();