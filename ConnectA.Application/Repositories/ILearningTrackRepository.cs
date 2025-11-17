using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface ILearningTrackRepository
{
    Task<LearningTrack> CreateLearningTrack(LearningTrack learningTrack);
    
    Task<LearningTrack?> GetLearningTrackById(Guid learningTrackId);
}