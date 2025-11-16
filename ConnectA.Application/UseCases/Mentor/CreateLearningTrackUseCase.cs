using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Enums;
using ConnectA.Domain.Exceptions;

namespace ConnectA.Application.UseCases.Mentor;

public class CreateLearningTrackUseCase(ILearningTrackRepository learningTrackRepository, ITrackStageRepository trackStageRepository, IUserRepository userRepository)
{
    
    public async Task<LearningTrack> CreateLearningTrack(LearningTrack learningTrack)
    {
        var seniorExists = await userRepository.GetUserByIdAsync(learningTrack.SeniorId);
        if (seniorExists is null)
            throw new UserNotFoundException(learningTrack.SeniorId);

        if (seniorExists.Type is not UserType.SENIOR)
            throw new InvalidSeniorRoleException(learningTrack.SeniorId);
        
        var createdLearningTrack = await learningTrackRepository.CreateLearningTrack(learningTrack);
         
        await trackStageRepository.CreateTrackStages(learningTrack.Stages);
        return createdLearningTrack;
    }
}