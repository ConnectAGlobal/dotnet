using ConnectA.Domain.Entities;
using JetBrains.Annotations;

namespace ConnectA.Tests.Entities;

[TestSubject(typeof(LearningTrack))]
public class LearningTrackTest
{

    [Fact]
    public void CreateLearningTrack_WhenTrackStageLessThan1_ShouldArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            var learningTrack = new LearningTrack(
                "Track Name", 
                "Track Description", 
                "INTERMEDIATE", 
                Guid.Empty, 
                new List<TrackStage>());
        });
    }
    
    [Fact]
    public void CreateLearningTrack_WhenTrackStageMoreThan1_ShouldCreateLearningTrackSuccessfully()
    {
        
        var stage = new TrackStage(
            "Stage 1", 
            "Stage Description", 
            "CHALLENGE", 
            1, 
            30, 
            "http://example.com");
        
       var learningTrack = new LearningTrack(
                "Track Name", 
                "Track Description", 
                "INTERMEDIATE", 
                Guid.Empty, 
                new List<TrackStage>()
                {
                    stage
                });
        
         Assert.NotNull(learningTrack);
         Assert.Equal(stage, learningTrack.Stages.First());
    }
}