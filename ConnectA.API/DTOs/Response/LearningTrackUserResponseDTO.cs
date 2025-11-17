using ConnectA.Domain.Enums;

namespace ConnectA.API.DTOs.Response;

public class LearningTrackUserResponseDTO(
    Guid id,
    Guid userId,
    Guid learningTrackId,
    Status status,
    double? score,
    DateTime startedAt,
    DateTime? completedAt)
{
    public Guid Id { get; set; } = id;
    public Guid UserId { get; set; } = userId;
    public Guid LearningTrackId { get; set; } = learningTrackId;

    public Status Status { get; set; } = status;
    public double? Score { get; set; } = score;
    public DateTime StartedAt { get; set; } = startedAt;
    public DateTime? CompletedAt { get; set; } = completedAt;
}