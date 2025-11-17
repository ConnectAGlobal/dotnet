namespace ConnectA.API.DTOs.Response;

public class LearningTrackResponseDTO(
    Guid id,
    string name,
    string description,
    string level,
    Guid seniorId,
    ICollection<TrackStageResponseDTO> stages,
    DateTime createdAt)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    public string Level { get; init; } = level;
    public Guid SeniorId { get; init; } = seniorId;
    public DateTime CreatedAt { get; init; } = createdAt;

    public ICollection<TrackStageResponseDTO> Stages { get; init; } = stages;
}