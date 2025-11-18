using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetUserByEmail(string email);
    Task<ICollection<User>> GetAvailableJuniorsAsync();
    Task<ICollection<User>> GetAvailableSeniorsAsync();
}