using IcomSpiSimulator.Api.Domains.HealthCheck;
using System.Reflection;
using IcomSpiSimulator.Api.Infrastructure.Extensions;
using IcomSpiSimulator.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiBasics()
    .AddSwaggerDocs()
    .AddDomainServices()
    .AddDatabaseServices(builder.Configuration)
    .AddHostedServices();
    
var app = builder.Build();

app.UseApiPipeline()
    .MapDomainEndpoints();
    
app.Run();