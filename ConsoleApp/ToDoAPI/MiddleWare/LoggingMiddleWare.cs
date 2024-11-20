using Serilog;
using Serilog.Core;

namespace ToDoAPI.MiddleWare;

public class LoggingMiddleWare: IMiddleware
{
    public  static readonly string LogFilePath = "Logs/log-.txt";
    
    public Logger Logger { get; private set; }
    
    public LoggingMiddleWare()
    {
        Logger = new LoggerConfiguration().MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(LogFilePath, rollingInterval: RollingInterval.Hour)
            .CreateLogger();
        
        Log.Information("Loglama başladı!");
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var logMessage = $"\nAPI Request: {context.Request.Method}: {context.Request.Scheme} {context.Request.Host}{context.Request.Path}{context.Request.QueryString}\n";

        context.Request.EnableBuffering();
        
        //gönderilen sorguyu yazdır 
        if (context.Request.ContentLength > 0 && context.Request.Body.CanRead)
        {
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                logMessage+= $"Request Body: {body}\n";

                // Stream'i sıfırla, böylece diğer middleware veya kontrolörler kullanabilir 
                context.Request.Body.Position = 0;
            }
        }
        logMessage+=($"Content Type: {context.Request.ContentType}");
        
        //gelen yanıt varsa yazdır
        //datetime'ı da logla

        
        await next(context);
        logMessage+=($"Response: {context.Response.StatusCode}");
        
        logMessage+=("\n**********************************");

        if (context.Response.StatusCode == 200)
        {
            Logger.Information(logMessage);
        }
        else
        {
            Logger.Error(logMessage);
        }
        
    }
}
//extention for binding middleware
public static class LoggingMiddleWareExtentions
{
    public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggingMiddleWare>();
        
    }
}