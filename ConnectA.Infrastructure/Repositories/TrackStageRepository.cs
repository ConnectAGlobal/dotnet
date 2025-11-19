using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

internal class TrackStageRepository(OracleContext context) : ITrackStageRepository
{
    
    public async Task CreateTrackStage(TrackStage trackStage)
    {
        await context.TrackStages.AddAsync(trackStage);
        await context.SaveChangesAsync();
    }
}