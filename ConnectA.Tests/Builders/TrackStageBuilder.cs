using ConnectA.Domain.Entities;

namespace ConnectA.Tests.Builders;

public static class TrackStageBuilder
{
    public static TrackStage CreateValidStage()
    {
        return new TrackStage(
            "Stage 1",
            "Stage Description",
            "CHALLENGE",
            1,
            30,
            "http://example.com"
        );
    }
    
}