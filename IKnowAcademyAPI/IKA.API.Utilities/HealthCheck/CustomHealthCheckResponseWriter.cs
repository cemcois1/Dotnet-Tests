using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace IKA.API.Utilities.HealthCheck;

public static class CustomHealthCheckResponseWriter
{
    public static Task WriteDetailedResponse(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            status = report.Status.ToString(),
            results = report.Entries.Select(entry => new
            {
                key = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                duration = entry.Value.Duration.TotalMilliseconds + " ms",
                data = entry.Value.Data // Ek veri eklendiğinde buraya gelir
            })
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            WriteIndented = true // JSON'u okunabilir hale getirir
        }));
    }
}