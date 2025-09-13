using IcomSpiSimulator.Api.Domains.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IcomSpiSimulator.Api.Infrastructure.Persistence.Configuration;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> b)
    {
        b.ToTable("participants");
        b.HasKey(x => x.Id);
        b.Property(x => x.Id).ValueGeneratedOnAdd();

        b.Property(x => x.Ispb)
            .IsRequired()
            .HasMaxLength(8);
        
        b.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        b.Property(x => x.Balance)
            .HasPrecision(18, 2)
            .HasDefaultValue(0);
    }
}