using ConnectA.Domain.Enums;

namespace ConnectA.API.DTOs.Request;

public class LearningTrackUserRequestDTO(Guid userId, Guid learningTrackId)
{
    public Guid UserId { get; init; } = userId;
    public Guid LearningTrackId { get; init; } = learningTrackId;
}