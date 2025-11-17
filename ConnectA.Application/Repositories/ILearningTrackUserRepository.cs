using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface ILearningTrackUserRepository
{
    Task<LearningTrackUser?> GetByMentoredAndTrackIdsAsync(Guid mentoredId, Guid trackId);
    
    Task AddAsync(LearningTrackUser learningTrackUser);
}