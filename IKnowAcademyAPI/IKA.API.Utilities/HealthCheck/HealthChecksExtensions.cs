using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace IKA.API.Utilities.HealthCheck;

public static class HealthChecksExtensions
{
    //google'a bağlanabiliyor mu
    public static IHealthChecksBuilder AddGoogleHealthCheck(this IHealthChecksBuilder healthChecksBuilder)
    {
        healthChecksBuilder.AddUrlGroup(new Uri("https://www.google.com/"), name: "Google Health Check", timeout: TimeSpan.FromSeconds(5));
        return healthChecksBuilder;
    }
    
    public static IHealthChecksBuilder AddMemoryHealthCheck(this IHealthChecksBuilder healthChecksBuilder, long maxMb)
    {
        maxMb = maxMb * 1024 * 1024;
        healthChecksBuilder.AddCheck("Memory Usage", () =>
        {
            var currentMemoryUsage = GC.GetTotalMemory(false);
            return currentMemoryUsage < maxMb 
                ? HealthCheckResult.Healthy($"Memory usage is OK: {currentMemoryUsage / (1024 * 1024)} MB")
                : HealthCheckResult.Unhealthy($"Memory usage is HIGH: {currentMemoryUsage / (1024 * 1024)} MB");
        });
        
        return healthChecksBuilder;
    }
    public static IHealthChecksBuilder AddSqlServerHealthCheck(this IHealthChecksBuilder healthChecksBuilder,
        string connectionString)
    {
        healthChecksBuilder.AddSqlServer(
            connectionString: connectionString,
            name: "SQL Server Health Check",
            timeout: TimeSpan.FromSeconds(5),
            failureStatus: HealthStatus.Unhealthy // Başarısızlık durumu
        );

        return healthChecksBuilder;
    }
}