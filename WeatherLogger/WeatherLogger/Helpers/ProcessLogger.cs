namespace WeatherLogger.Helpers;

public static class ProcessLogger
{
    private static string LogFileName;

    public static void Configure(ConfigurationManager builderConfiguration)
    {
        Console.WriteLine("LogFileName Configure Ediliyor");

        try
        {
            var logFileName = builderConfiguration.GetSection("Logging:FileName").Get<string>();
            if (!string.IsNullOrEmpty(logFileName))
            {
                LogFileName = logFileName;
            }
            else
            {
                Console.WriteLine("LogFileName is not defined in appsettings.json");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Configure Error Message:"+e);
            throw;
        }
    }
    
    public static void Log(string message)
    { 
        try
        {
            File.AppendAllText(LogFileName, $"{DateTime.Now}_{message}\n");
            Console.WriteLine(message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{DateTime.Now} Base Log Message Gived Error Message:"+e);
            throw;
        }
    }
    public static void Error(string message)
    {
        try
        {
            File.AppendAllText(LogFileName, $"{DateTime.Now}_{message}\n");
            Console.WriteLine(message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Base Log Error Message Gived Error Message:"+e);
            throw;
        }
    }


}