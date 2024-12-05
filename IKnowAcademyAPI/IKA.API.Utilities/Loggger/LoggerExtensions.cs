using Microsoft.Extensions.Logging;
using Serilog;

namespace IKA.API.Utilities.Loggger;

public static class LoggerExtensions
{
    public static void ConfigureSerilog(this ILoggingBuilder loggingBuilder, string logFilePath)
    {
        var log = new LoggerConfiguration().MinimumLevel.Information()
            .WriteTo.File(path: logFilePath, rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console()
            .CreateLogger();
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(log);

    }
    
}