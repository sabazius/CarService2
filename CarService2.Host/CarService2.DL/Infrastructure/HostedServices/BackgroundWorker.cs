using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarService2.DL.Infrastructure.HostedServices;

internal class BackgroundWorker : BackgroundService
{
    private readonly ILogger<HostedWorker> _logger;

    public BackgroundWorker(ILogger<HostedWorker> logger)
    {
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Test: {DateTime.UtcNow}");
                await Task.Delay(1000, cancellationToken);
            }
        }, cancellationToken);

        return Task.CompletedTask;
    }
}