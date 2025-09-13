using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IcomSpiSimulator.Api.Domains.HealthCheck;

public static class HealthCheckModule
{
    public static IEndpointRouteBuilder MapHealthCheck(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/health").WithTags("Health");

        group.MapGet("/live", async Task<Ok<object>> (IHealthCheckService service, CancellationToken ct) =>
        {
            var res = await service.LiveAsync(ct);
            return TypedResults.Ok(res);
        });
        
        group.MapGet("/ready", async Task<Ok<object>> (IHealthCheckService service, CancellationToken ct) =>
        {
            var res = await service.ReadyAsync(ct);
            return TypedResults.Ok(res);
        });
        
        return routes;
    }
}
