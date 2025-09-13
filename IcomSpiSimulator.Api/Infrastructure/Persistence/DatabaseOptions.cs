namespace IcomSpiSimulator.Api.Infrastructure.Persistence;

public class DatabaseOptions
{
    public const string SectionName = "DatabaseOptions";
    public string ConnectionString { get; set; } = string.Empty;
}