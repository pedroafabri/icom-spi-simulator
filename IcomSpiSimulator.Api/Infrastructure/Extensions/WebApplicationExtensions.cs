using IcomSpiSimulator.Api.Domains.HealthCheck;

namespace IcomSpiSimulator.Api.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }

    public static WebApplication MapDomainEndpoints(this WebApplication app)
    {
        app.MapHealthCheck();
        return app;
    }
}