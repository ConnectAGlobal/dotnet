
namespace ConnectA.API.DTOs.Request;

public class LearningTrackRequestDTO(
    string name,
    string description,
    string level,
    Guid seniorId,
    ICollection<TrackStageRequestDTO> trackStages)
{
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    public string Level { get; init; } = level;
    public Guid SeniorId { get; init; } = seniorId;
    public ICollection<TrackStageRequestDTO> TrackStages { get; init; } = trackStages;
}