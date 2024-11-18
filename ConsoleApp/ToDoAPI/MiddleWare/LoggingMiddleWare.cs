namespace ToDoAPI.MiddleWare;

public class LoggingMiddleWare: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine($"Method: {context.Request.Method}");
        Console.WriteLine($"Request: {context.Request.Path}");
        
        context.Request.EnableBuffering();
        
        //gönderilen sorguyu yazdır 
        if (context.Request.ContentLength > 0 && context.Request.Body.CanRead)
        {
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                Console.WriteLine($"Body: {body}");

                // Stream'i sıfırla, böylece diğer middleware veya kontrolörler kullanabilir
                context.Request.Body.Position = 0;
            }
        }
        Console.WriteLine($"Content Type: {context.Request.ContentType}");
        Console.WriteLine("**********************************");

        
        await next(context);
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