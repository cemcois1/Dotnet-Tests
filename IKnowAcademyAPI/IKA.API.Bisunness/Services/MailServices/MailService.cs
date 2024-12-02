
namespace IKA.API.Services.Services;

//user contranct doldurulduğunda usera mail at 

public class MailService: BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }
}