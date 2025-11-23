using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface ILearningTrackUserRepository
{
    Task<LearningTrackUser?> GetByMentoredAndTrackIdsAsync(Guid mentoredId, Guid trackId);
    
    Task AddAsync(LearningTrackUser learningTrackUser);
    
    Task<(IEnumerable<LearningTrackUser> Items, int TotalCount)>
        GetFollowedLearningTracksPagedAsync(Guid userId, int page, int pageSize);
    
    Task<LearningTrackUser?> GetByIdAsync(Guid id);
    Task UpdateAsync(LearningTrackUser learningTrackUser);
    Task DeleteAsync(Guid id);
}