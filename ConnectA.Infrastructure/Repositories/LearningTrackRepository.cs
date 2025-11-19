using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

internal class LearningTrackRepository(OracleContext context) : ILearningTrackRepository
{
    public async Task<LearningTrack> CreateLearningTrack(LearningTrack learningTrack)
    {
        await context.LearningTracks.AddAsync(learningTrack);
        await context.SaveChangesAsync();
        return learningTrack;
    }
    
    public async Task<LearningTrack?> GetLearningTrackById(Guid learningTrackId)
    {
        return await context.LearningTracks.
            FindAsync(learningTrackId);
    }
}