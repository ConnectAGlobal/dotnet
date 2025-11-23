using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

internal class MentorshipChallengeMapping : IEntityTypeConfiguration<MentorshipChallenge>
{
    public void Configure(EntityTypeBuilder<MentorshipChallenge> builder)
    {
        builder.ToTable("mentorship_challenges");

        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.MentorshipMatchId)
            .HasColumnName("mentorship_match_id")
            .IsRequired();

        builder.Property(mc => mc.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(mc => mc.Description)
            .IsRequired();
        
        builder.Property(mc => mc.Status)
            .IsRequired();

        builder.Property(mc => mc.CreatedAt)
            .IsRequired();

        builder.HasOne(mc => mc.MentorshipMatch)
            .WithMany(mc => mc.Challenges)
            .HasForeignKey(mc => mc.MentorshipMatchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}