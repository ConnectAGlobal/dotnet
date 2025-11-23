using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

internal class MentorshipEvaluationMapping : IEntityTypeConfiguration<MentorshipEvaluation>
{
    public void Configure(EntityTypeBuilder<MentorshipEvaluation> builder)
    {
        builder.ToTable("mentorship_evaluations");

        builder.HasKey(me => me.Id);

        builder.Property(me => me.Evaluator)
            .IsRequired();

        builder.Property(me => me.Rating)
            .IsRequired();

        builder.Property(me => me.Comment)
            .HasMaxLength(1000);

        builder.Property(me => me.EvaluatedAt)
            .IsRequired();

        builder.HasOne(me => me.MentorshipMatch)
            .WithMany(mm => mm.Evaluations)
            .HasForeignKey(me => me.MentorshipMatchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}