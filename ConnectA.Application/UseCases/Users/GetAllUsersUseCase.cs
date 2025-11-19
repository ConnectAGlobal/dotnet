using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Users;

public class GetAllUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersUseCase(IUserRepository userRepository) => _userRepository = userRepository;

    public Task<ICollection<User>> Execute()
        => _userRepository.GetAllAsync();
}
