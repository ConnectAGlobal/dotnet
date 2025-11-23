using ConnectA.Domain.Entities;

namespace ConnectA.Tests.Builders;

public static class LearningTrackBuilder
{
    public static LearningTrack CreateValidTrack(Guid seniorId)
    {
        return new LearningTrack(
            "Track Name",
            "Track Description",
            "INTERMEDIATE",
            seniorId,
            new List<TrackStage>
            {
                TrackStageBuilder.CreateValidStage()
            }
        );
    } 
}