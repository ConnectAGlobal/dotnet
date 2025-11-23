using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Mentor;

public class AddTrackStageUseCase(ILearningTrackRepository learningTrackRepository, ITrackStageRepository trackStageRepository)
{
    public async Task<TrackStage> AddTrackStage(Guid learningTrackId, TrackStage trackStage)
    {
        var learningTrack = await learningTrackRepository.GetLearningTrackById(learningTrackId);
        if (learningTrack is null)
            throw new Exception("Learning track not found.");

        trackStage.LearningTrackId = learningTrackId;
        await trackStageRepository.CreateTrackStage(trackStage);
        return trackStage;
       
    }
}