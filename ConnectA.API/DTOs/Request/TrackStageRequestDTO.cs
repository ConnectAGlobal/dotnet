namespace ConnectA.API.DTOs.Request;

public class TrackStageRequestDTO(
    Guid? learningTrackId,
    string title,
    string description,
    string activityType,
    int order,
    int estimatedDuration,
    string? resourceLink)
{
    public Guid? LearningTrackId { get; init; } = learningTrackId;
    public string Title { get; init; } = title;
    public string Description { get; init; } = description;
    public string ActivityType { get; init; } = activityType;
    public int Order { get; init; } = order;
    public int EstimatedDuration { get; init; } = estimatedDuration;
    public string? ResourceLink { get; init; } = resourceLink;
}