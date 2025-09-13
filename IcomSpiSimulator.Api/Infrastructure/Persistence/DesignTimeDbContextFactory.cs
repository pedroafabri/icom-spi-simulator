using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IcomSpiSimulator.Api.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        
        var cwd = Directory.GetCurrentDirectory();
        var projectDir = Directory.Exists(Path.Combine(cwd, "IcomSpiSimulator.Api"))
            ? Path.Combine(cwd, "IcomSpiSimulator.Api")
            : cwd;

        var config = new ConfigurationBuilder()
            .SetBasePath(projectDir)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var conn = config.GetSection(DatabaseOptions.SectionName)["ConnectionString"]
                   ?? config.GetConnectionString("Postgres")
                   ?? "Host=localhost;Port=5432;Database=spi;Username=spi;Password=spi";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(conn)
            .Options;

        return new AppDbContext(options);
    }
}