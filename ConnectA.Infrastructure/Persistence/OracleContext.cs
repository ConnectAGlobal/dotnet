using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Persistence;

public class OracleContext(DbContextOptions<OracleContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}