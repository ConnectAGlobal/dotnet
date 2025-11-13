using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Profiles;

public class CreateProfileUseCase(IProfileRepository profileRepository, IUserRepository userRepository)
{
    public async Task<Profile> CreateProfile(Profile profile)
    {
        var user = await userRepository.GetUserByIdAsync(profile.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        profile.User = user;
        return await profileRepository.CreateProfileAsync(profile);
    }
}