using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
}