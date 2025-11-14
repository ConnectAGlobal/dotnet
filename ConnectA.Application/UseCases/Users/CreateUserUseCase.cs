using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Application.UseCases.Users;

public class CreateUserUseCase(IUserRepository userRepository)
{
    public async Task<User> CreateUser(User user)
    {
        var existingUser = await userRepository.GetUserByEmail(user.Email);
        if (existingUser != null)
        {
           throw new UserAlreadyExistsException(user.Email);  
        }
        return await userRepository.CreateUser(user);
    }
}