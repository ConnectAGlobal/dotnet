using ConnectA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectA.Infrastructure.Mappings;

public class ProfileMapping : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("profiles");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(e => e.Biography)
            .HasColumnName("biography")
            .HasMaxLength(1000);
        
        builder.Property(e => e.Skills)
            .HasColumnName("skills")
            .HasMaxLength(500);
        
        builder.Property(e => e.Experience)
            .HasColumnName("experience")
            .HasMaxLength(2000);
        
        builder.Property(e => e.Objectives)
            .HasColumnName("objectives")
            .HasMaxLength(2000);
        
        builder.Property(e => e.Location)
            .HasColumnName("location")
            .HasMaxLength(150);
        
        builder.Property(e => e.Lenguages)
            .HasColumnName("lenguages")
            .HasMaxLength(500);
        
        builder.HasOne(e => e.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<Profile>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}