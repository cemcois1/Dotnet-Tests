using System.ServiceModel;

namespace WeatherLogger.Services;

[ServiceContract]
public class DailyWeatherSoapService
{
    [OperationContract]
    public String HelloWorld()
    {
        return "Hello World";
    }
    
    [OperationContract]
    public String HelloName(string name)
    {
        return "Hello " + name;
    }
    
    [OperationContract]
    public int Add(int a,int b)
    {
        return a + b;
    }
}