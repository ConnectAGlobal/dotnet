using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface ITrackStageRepository
{
    Task CreateTrackStage(TrackStage trackStage);
}