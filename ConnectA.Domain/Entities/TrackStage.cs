using ConnectA.Domain.Enums;
using ConnectA.Domain.Helper;

namespace ConnectA.Domain.Entities;

public class TrackStage
{
    public Guid Id { get; set; }
    public Guid LearningTrackId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ActivityType ActivityType { get; set; }
    public int Order { get; set; }
    public int EstimatedDuration { get; set; }
    public string? ResourceLink { get; set; }
    
    public virtual LearningTrack LearningTrack { get; set; }
    
    private TrackStage() {}
    
    public TrackStage(string title, string description, string activityType, int order, int estimatedDuration, string? resourceLink)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ActivityType = TransformInEnum.ParseEnum<ActivityType>(activityType);
        Order = order;
        EstimatedDuration = estimatedDuration;
        ResourceLink = resourceLink;
    }
    
    public void SetLearningTrackId(Guid learningTrackId)
    {
        LearningTrackId = learningTrackId;
    }
}