using Microsoft.EntityFrameworkCore;

namespace IcomSpiSimulator.Api.Infrastructure.Persistence.Services;

public class MigrationHostedService(IServiceProvider sp, ILogger<MigrationHostedService> log)
    : IHostedService
{
    public async Task StartAsync(CancellationToken ct)
    {
        log.LogInformation("MigrationHostedService is starting.");
        var env = sp.GetRequiredService<IHostEnvironment>();
        if (!env.IsDevelopment())
        {
            log.LogInformation("Skipping migrations (not Development)");
            return;
        }

        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            log.LogInformation("Applying EF Core migrations...");
            await db.Database.MigrateAsync(ct);
            log.LogInformation("Migrations applied successfully.");
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Error applying migrations");
            throw;
        }
    }

    public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
}