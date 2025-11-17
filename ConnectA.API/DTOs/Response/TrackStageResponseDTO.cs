namespace ConnectA.API.DTOs.Response;

public class TrackStageResponseDTO
{
    public Guid Id { get; init; }
    public Guid LearningTrackId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string ActivityType { get; init; }
    public int Order { get; init; }
    public int EstimatedDuration { get; init; }
    public string? ResourceLink { get; init; }
}