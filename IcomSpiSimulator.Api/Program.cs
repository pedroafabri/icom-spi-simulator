using IcomSpiSimulator.Api.Domains.HealthCheck;
using System.Reflection;
using IcomSpiSimulator.Api.Infrastructure.Extensions;
using IcomSpiSimulator.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("Postgres")
           ?? builder.Configuration["ConnectionStrings:Postgres"]
           ?? "Host=localhost;Port=5432;Database=spi;Username=spi;Password=spi";

builder.Services
    .AddApiBasics()
    .AddSwaggerDocs()
    .AddDomainServices()
    .AddDatabaseServices(builder.Configuration);
    
var app = builder.Build();

app.UseApiPipeline()
    .MapDomainEndpoints();
    
app.Run();