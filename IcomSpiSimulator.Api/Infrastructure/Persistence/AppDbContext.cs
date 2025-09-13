using System.Reflection;
using IcomSpiSimulator.Api.Domains.Participants;
using IcomSpiSimulator.Api.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IcomSpiSimulator.Api.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
    public DbSet<Participant> Participants => Set<Participant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}