using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

public class TrackStageMapping : IEntityTypeConfiguration<TrackStage>
{
    public void Configure(EntityTypeBuilder<TrackStage> builder)
    {
        builder.ToTable("track_stages");
        
        builder.HasKey(ts => ts.Id);
        
        builder.Property(ts => ts.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(ts => ts.LearningTrackId)
            .HasColumnName("learning_track_id")
            .IsRequired();
        
        builder.Property(ts => ts.Title)
            .HasColumnName("title")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(ts => ts.Description)
            .HasColumnName("description")
            .HasMaxLength(2000)
            .IsRequired();
        
        builder.Property(ts => ts.ActivityType)
            .HasColumnName("activity_type")
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(ts => ts.Order)
            .HasColumnName("order")
            .IsRequired();
        
        builder.Property(ts => ts.EstimatedDuration)
            .HasColumnName("estimated_duration")
            .IsRequired();
        
        builder.Property(ts => ts.ResourceLink)
            .HasColumnName("resource_link")
            .HasMaxLength(500)
            .IsRequired(false);
        
        builder.HasOne(ts => ts.LearningTrack)
            .WithMany(lt => lt.Stages)
            .HasForeignKey(ts => ts.LearningTrackId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}