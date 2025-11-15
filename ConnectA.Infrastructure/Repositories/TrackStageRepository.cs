using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

internal class TrackStageRepository(OracleContext context) : ITrackStageRepository
{
    public async Task CreateTrackStages(ICollection<TrackStage> trackStages)
    {
        await context.TrackStages.AddRangeAsync(trackStages);
        await context.SaveChangesAsync();
    }
}