namespace WeatherLogger.Models;

public class RawWeatherData
{
    public List<Weather> Weather { get; set; }
    public Main Main { get; set; }
    public Wind Wind { get; set; }
    public string Name { get; set; }
}

public class Wind
{
    public double Speed { get; set; }
    public int Deg { get; set; }
}

public class Main
{
    public double Temp { get; set; }
}

public class Weather
{
    public string Main { get; set; }
}