using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

public class UserRepository(OracleContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }
}