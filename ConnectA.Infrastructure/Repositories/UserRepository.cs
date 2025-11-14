using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Repositories;

public class UserRepository(OracleContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await context.Users.FindAsync(userId);
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}