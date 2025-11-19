using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Enums;
using ConnectA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Infrastructure.Repositories;

internal class UserRepository(OracleContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await context.Users.Include(u => u.Profile)
            .Include(u => u.LearningTracksAsSenior)
            .Include(u => u.LearningTracksFolows)
            .Include(u => u.MatchesAsJunior)
            .Include(u => u.MatchesAsSenior)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<ICollection<User>> GetAvailableJuniorsAsync()
    {
        return await context.Users
            .Where(u => u.Type == UserType.JOVEM && u.MatchesAsSenior.Count == 0)
            .ToListAsync();
    }
    
    public async Task<ICollection<User>> GetAvailableSeniorsAsync()
    {
        return await context.Users
            .Where(u => u.Type == UserType.SENIOR && u.MatchesAsJunior.Count == 0)
            .ToListAsync();
    }
    
    public async Task<ICollection<User>> GetAllAsync()
    {
        return await context.Users
            .Include(u => u.Profile)
            .Include(u => u.LearningTracksAsSenior)
            .Include(u => u.LearningTracksFolows)
            .Include(u => u.MatchesAsJunior)
            .Include(u => u.MatchesAsSenior)
            .ToListAsync();
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user == null)
            throw new UserNotFoundException(userId);

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
    
}