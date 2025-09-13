using IcomSpiSimulator.Api.Domains.HealthCheck;
using System.Reflection;
using IcomSpiSimulator.Api.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiBasics()
    .AddSwaggerDocs()
    .AddDomainServices();
    
var app = builder.Build();

app.UseApiPipeline()
    .MapDomainEndpoints();
    
app.Run();