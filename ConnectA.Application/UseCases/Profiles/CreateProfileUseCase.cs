using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Application.UseCases.Profiles;

public class CreateProfileUseCase(IProfileRepository profileRepository, IUserRepository userRepository)
{
    public async Task<Profile> CreateProfile(Profile profile)
    {
        var user = await userRepository.GetUserByIdAsync(profile.UserId);
        if (user == null)
        {
            throw new UserNotFoundException(profile.UserId);
        }
        
        profile.User = user;
        return await profileRepository.CreateProfileAsync(profile);
    }
}