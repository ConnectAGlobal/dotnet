using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Users;

public class CreateUserUseCase(IUserRepository userRepository)
{
    public async Task<User> CreateUser(User user)
    {
        return await userRepository.CreateUser(user);
    }
}