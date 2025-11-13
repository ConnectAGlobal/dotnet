using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

public class LearningTrackMapping : IEntityTypeConfiguration<LearningTrack>
{
    public void Configure(EntityTypeBuilder<LearningTrack> builder)
    {
        builder.ToTable("learning_tracks");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasMaxLength(2000)
            .IsRequired();
        
        builder.Property(e => e.Level)
            .HasColumnName("level")
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(e => e.SeniorId)
            .HasColumnName("senior_id")
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.HasOne(e => e.Senior)
            .WithMany(u => u.LearningTracks)
            .HasForeignKey(e => e.SeniorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}