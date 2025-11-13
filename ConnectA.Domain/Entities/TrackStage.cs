using ConnectA.Domain.Enums;

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
    
    public TrackStage(Guid learningTrackId, string title, string description, ActivityType activityType, int order, int estimatedDuration, string? resourceLink)
    {
        Id = Guid.NewGuid();
        LearningTrackId = learningTrackId;
        Title = title;
        Description = description;
        ActivityType = activityType;
        Order = order;
        EstimatedDuration = estimatedDuration;
        ResourceLink = resourceLink;
    }
}