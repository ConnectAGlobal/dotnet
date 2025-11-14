using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Mappings;

public class MentorshipMatchMapping : IEntityTypeConfiguration<MentorshipMatch>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MentorshipMatch> builder)
    {
        builder.ToTable("mentorship_matches");

        builder.HasKey(mm => mm.Id);
        
        builder.Property(mm => mm.JuniorId)
            .HasColumnName("junior_id")
            .IsRequired();
        
        builder.Property(mm => mm.SeniorId)
            .HasColumnName("senior_id")
            .IsRequired();

        builder.Property(mm => mm.CompatibilityScore)
            .IsRequired();

        builder.Property(mm => mm.MatchedAt)
            .IsRequired();

        builder.HasOne(mm => mm.Junior)
            .WithMany(u => u.MatchesAsJunior)
            .HasForeignKey(mm => mm.JuniorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(mm => mm.Senior)
            .WithMany(u => u.MatchesAsSenior)
            .HasForeignKey(mm => mm.SeniorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}