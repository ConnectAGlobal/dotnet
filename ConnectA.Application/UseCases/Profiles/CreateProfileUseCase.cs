using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Profiles;

public class CreateProfileUseCase(IProfileRepository profileRepository)
{
    public async Task<Profile> CreateProfile(Profile profile)
    {
        
        return await profileRepository.CreateProfileAsync(profile);
    }
}