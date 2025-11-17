using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Application.UseCases.Mentored;

public class FollowLearningTrackUseCase(
    ILearningTrackRepository learningTrackRepository,
    ILearningTrackUserRepository learningTrackUserRepository,
    IUserRepository userRepository
    )
{
    public async Task<LearningTrackUser> FollowLearningTrack(LearningTrackUser createdTrackStage)
    {
        var user = await userRepository.GetUserByIdAsync(createdTrackStage.UserId);
        if (user == null)
        {
            throw new UserNotFoundException(createdTrackStage.UserId);
        }
        
        var learningTrack = await learningTrackRepository.GetLearningTrackById(createdTrackStage.LearningTrackId);
        if (learningTrack == null)
        {
            throw new ArgumentException("Learning track not found.");
        }
        
        var existingTrackUser = await learningTrackUserRepository.GetByMentoredAndTrackIdsAsync(createdTrackStage.UserId, createdTrackStage.LearningTrackId);
        if (existingTrackUser != null)
        {
            throw new ArgumentException("Mentored is already following this learning track.");
        }
        
        await learningTrackUserRepository.AddAsync(createdTrackStage);
        return createdTrackStage;
    }
}