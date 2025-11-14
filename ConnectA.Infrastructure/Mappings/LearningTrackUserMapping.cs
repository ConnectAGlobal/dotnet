using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

public class LearningTrackUserMapping : IEntityTypeConfiguration<LearningTrackUser>
{
    public void Configure(EntityTypeBuilder<LearningTrackUser> builder)
    {
        builder.ToTable("learning_track_users");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(e => e.LearningTrackId)
            .HasColumnName("learning_track_id")
            .IsRequired();
        
        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(e => e.Score)
            .HasColumnName("score")
            .IsRequired(false);
        
        builder.Property(e => e.StartedAt)
            .HasColumnName("started_at")
            .IsRequired();
        
        builder.Property(e => e.CompletedAt)
            .HasColumnName("completed_at")
            .IsRequired(false);
        
        builder.HasOne(e => e.User)
            .WithMany(u => u.LearningTracksFolows)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(e => e.LearningTrack)
            .WithMany(lt => lt.Users)
            .HasForeignKey(e => e.LearningTrackId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}