using ConnectA.Domain.Enums;

namespace ConnectA.API.DTOs.Request;

public class LearningTrackUserRequestDTO(Guid userId, Guid learningTrackId)
{
    public Guid UserId { get; set; } = userId;
    public Guid LearningTrackId { get; set; } = learningTrackId;
}