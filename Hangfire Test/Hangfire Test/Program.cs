using Hangfire_Test.Controllers;
using Hangfire_Test.Services;
using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<WeatherForecastController>();
builder.Services.AddHostedService<PeriodicalyLoggingService>();


builder.Services.AddHangfire(config => { config.UseMemoryStorage(); });
builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development mode!!");
    app.UseSwagger(); // Swagger JSON endpoint
    app.UseSwaggerUI(); // Swagger UI
}

app.MapControllers();

app.UseHangfireDashboard("/hangfire");
app.UseHangfireServer();

Console.WriteLine("http://localhost:5044/hangfire");

Console.WriteLine("http://localhost:5044/swagger/index.html\n");

app.Run();