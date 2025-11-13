using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Persistence;

public class OracleContext(DbContextOptions<OracleContext> options) : DbContext(options)
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProfileMapping());
    }
}