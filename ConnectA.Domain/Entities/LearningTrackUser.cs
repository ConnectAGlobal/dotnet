using ConnectA.Domain.Enums;

namespace ConnectA.Domain.Entities;

public class LearningTrackUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LearningTrackId { get; set; }

    public Status Status { get; set; }
    public double? Score { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public virtual User User { get; set; }
    public virtual LearningTrack LearningTrack { get; set; }
    
    private LearningTrackUser() {}
    
    public LearningTrackUser(Guid userId, Guid learningTrackId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        LearningTrackId = learningTrackId;
        Status = Status.IN_PROGRESS;
        StartedAt = DateTime.UtcNow;
    }
}