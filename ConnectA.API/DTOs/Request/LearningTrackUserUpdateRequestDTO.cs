using ConnectA.Domain.Enums;

namespace ConnectA.API.DTOs.Request;

public class LearningTrackUserUpdateRequestDTO(Status? status, double? score, DateTime? completedAt)
{
    public Status? Status { get; set; } = status;
    public double? Score { get; set; } = score;
    public DateTime? CompletedAt { get; set; } = completedAt;
}
