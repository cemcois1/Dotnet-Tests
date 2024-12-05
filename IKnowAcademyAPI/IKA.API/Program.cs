using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Repositories;
using IKA.API.Services.Services.DataDisplayers.Course;
using IKA.API.Utilities;
using IKA.API.Utilities.HealthCheck;
using IKA.API.Utilities.Loggger;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
var logFilePath = builder.Configuration["Logging:LogFilePath"];

// Serilog'u yapılandır
builder.Logging.ConfigureSerilog(logFilePath);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

builder.Services.AddEndpointsApiExplorer();

try
{
    builder.Services.AddScoped<CourseRepository>();
    builder.Services.AddScoped<ICourseDataCRUDService, CourseCrudService>();
    builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });

    builder.Services.AddControllers();
    builder.Services.AddHealthChecks()
        .AddSqlServerHealthCheck(connectionString)
        .AddMemoryHealthCheck(100)
        .AddGoogleHealthCheck()
        .AddStorgeHealthCheck();

}
catch (Exception e)
{
    Console.WriteLine("Servisleri yüklerken hata oluştu."+e);
    throw;
}
var app = builder.Build();

try
{
    app.MapHealthChecks("/healthz", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        ResponseWriter = CustomHealthCheckResponseWriter.WriteDetailedResponse
    });
    app.MapControllers();
}
catch (Exception e)
{
    Console.WriteLine("Uygulamayı çalıştırırken hata oluştu."+e);
    throw;
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();