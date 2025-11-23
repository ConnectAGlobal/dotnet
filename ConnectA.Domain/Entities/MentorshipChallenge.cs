using ConnectA.Domain.Enums;

namespace ConnectA.Domain.Entities;

public class MentorshipChallenge
{
    public Guid Id { get; set; }
    public Guid MentorshipMatchId { get; set; }

    public string Title { get; set; } 
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public virtual MentorshipMatch MentorshipMatch { get; set; }
    
    private MentorshipChallenge() {}
    
    public MentorshipChallenge(Guid mentorshipMatchId, string title, string description)
    {
        Id = Guid.NewGuid();
        MentorshipMatchId = mentorshipMatchId;
        Title = title;
        Description = description;
        Status = Status.IN_PROGRESS;
        CreatedAt = DateTime.UtcNow;
    }
}