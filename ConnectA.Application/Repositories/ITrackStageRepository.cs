using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface ITrackStageRepository
{
    Task CreateTrackStages(ICollection<TrackStage> trackStages);
}