namespace IcomSpiSimulator.Api.Domains.HealthCheck;

public interface IHealthCheckService
{
    Task<object> LiveAsync(CancellationToken cancellationToken);
    Task<object> ReadyAsync(CancellationToken cancellationToken);
}