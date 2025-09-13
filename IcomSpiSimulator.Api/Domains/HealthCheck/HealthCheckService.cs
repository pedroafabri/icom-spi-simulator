namespace IcomSpiSimulator.Api.Domains.HealthCheck;

public class HealthCheckService(ILogger<HealthCheckService> logger) : IHealthCheckService
{
    private readonly ILogger<HealthCheckService> _logger = logger;

    public Task<object> LiveAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting live health check");
        return Task.FromResult<object>(new { status = "live" });
    }

    public Task<object> ReadyAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting ready health check");
        return Task.FromResult<object>(new { status = "ready" });
    }
}