using System.Reflection;
using IcomSpiSimulator.Api.Infrastructure.Persistence;
using IcomSpiSimulator.Api.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace IcomSpiSimulator.Api.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiBasics(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddHealthChecks();
        return services;
    }

    public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "SPI Simulator API", Version = "v1" });

            var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xml);
            if (File.Exists(xmlPath))
                opt.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        });
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<Domains.HealthCheck.IHealthCheckService, Domains.HealthCheck.HealthCheckService>();
        return services;
    }

    public static IServiceCollection AddLoggingServices(this IServiceCollection services)
    {
        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
        });
        return services;
    }

    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>((sp, opt) =>
        {
            var cs = config["Database:ConnectionString"] 
                     ?? config.GetConnectionString("Postgres");

            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException(
                    "Database connection string is empty. " +
                    "Set Database__ConnectionString env var or ConnectionStrings:Postgres.");

            opt.UseNpgsql(cs);
        });

        return services;
    }

    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<MigrationHostedService>();
        return services;
    }
}