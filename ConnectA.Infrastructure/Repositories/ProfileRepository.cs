using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

public class ProfileRepository(OracleContext context) : IProfileRepository
{
    public async Task<Profile> CreateProfileAsync(Profile profile)
    {
        await context.Profiles.AddRangeAsync(profile);
        await context.SaveChangesAsync();
        return profile;
    }
}