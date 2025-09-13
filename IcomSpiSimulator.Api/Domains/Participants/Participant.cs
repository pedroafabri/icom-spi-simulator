namespace IcomSpiSimulator.Api.Domains.Participants;

public class Participant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Ispb { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
    public string? WebhookUrl { get; set; }
    public string? WebhookSecret { get; set; }
}