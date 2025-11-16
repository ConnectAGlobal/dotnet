using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

internal class ProfileRepository(OracleContext context) : IProfileRepository
{
    public async Task CreateProfileAsync(Profile profile)
    {
        await context.Profiles.AddRangeAsync(profile);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateProfileAsync(Profile profile)
    {
        context.Profiles.Update(profile);
        await context.SaveChangesAsync();
    }
}