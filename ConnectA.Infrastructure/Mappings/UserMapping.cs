using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

internal class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(e => e.Type)
            .HasColumnName("type")
            .HasMaxLength(50)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(e => e.Active)
            .HasColumnName("active")
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(e => e.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired();
        
        builder.Property(e => e.PasswordSalt)
            .HasColumnName("password_salt")
            .IsRequired();
        
        builder.HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.LearningTracksFolows)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);
        
        builder.HasMany<LearningTrack>()
            .WithOne(t => t.Senior)
            .HasForeignKey(t => t.SeniorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}