using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Repositories;

internal class LearningTrackUserRepository(OracleContext context) : ILearningTrackUserRepository
{
    public async Task<LearningTrackUser?> GetByMentoredAndTrackIdsAsync(Guid mentoredId, Guid trackId)
    {
        return await context.LearningTrackUsers
            .FindAsync(mentoredId, trackId);
    }

    public async Task AddAsync(LearningTrackUser learningTrackUser)
    {
        await context.LearningTrackUsers.AddAsync(learningTrackUser);
        await context.SaveChangesAsync();
    }
    
    public async Task<(IEnumerable<LearningTrackUser>, int)> 
        GetFollowedLearningTracksPagedAsync(Guid userId, int page, int pageSize)
    {
        var query = context.LearningTrackUsers
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.StartedAt);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}