using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Application.UseCases.Users;

public class EditProfileUseCase(IUserRepository userRepository, IProfileRepository profileRepository)
{
    public async Task<User> EditProfile(Guid userId, Profile profile)
    {
        var user = await userRepository.GetUserByIdAsync(userId);
        if (user == null)
            throw new UserNotFoundException(userId);
        
        user.Profile.UpdateProfile(profile);
        await profileRepository.UpdateProfileAsync(user.Profile);
        return user;
    }
}