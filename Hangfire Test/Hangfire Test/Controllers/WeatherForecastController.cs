
using Hangfire_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire_Test.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController: ControllerBase
{
    
    string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("")]
    public IActionResult GetData()
    {
        try
        {
            Console.WriteLine("GetData worked");
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherData()
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                .ToArray();
            return Ok(forecast);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NoContent();
            throw;
            
        }

        return NotFound();

    }
    
    
    [HttpGet("{id}")]
    public IActionResult GetData(int id)
    {
        try
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherData()
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                .ToArray();
            if (id>=0 && id<forecast.Length)
            {
                return Ok(forecast[id]);

            }
            else
            {
                return NotFound();
            }


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NoContent();
            throw;
            
        }

        return NotFound();

    }
}