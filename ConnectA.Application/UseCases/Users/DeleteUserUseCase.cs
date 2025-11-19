using ConnectA.Application.Repositories;

namespace ConnectA.Application.UseCases.Users;

public class DeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository userRepository) => _userRepository = userRepository;

    public Task Execute(Guid userId)
        => _userRepository.DeleteUserAsync(userId);
}
