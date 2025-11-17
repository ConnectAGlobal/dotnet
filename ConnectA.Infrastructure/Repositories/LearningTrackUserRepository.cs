using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

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
}