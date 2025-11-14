using ConnectA.Domain.Enums;

namespace ConnectA.Domain.Entities;

public class MentorshipEvaluation
{
    public Guid Id { get; set; }
    public Guid MentorshipMatchId { get; set; }

    public UserType Evaluator { get; set; }
    public int Rating { get; set; } // 1 to 5
    public string? Comment { get; set; }
    public DateTime EvaluatedAt { get; set; }
    
    public virtual MentorshipMatch MentorshipMatch { get; set; }
    
    private MentorshipEvaluation() {}
    
    public MentorshipEvaluation(Guid mentorshipMatchId, UserType evaluator, int rating, string? comment)
    {
        Id = Guid.NewGuid();
        MentorshipMatchId = mentorshipMatchId;
        Evaluator = evaluator;
        Rating = rating;
        Comment = comment;
        EvaluatedAt = DateTime.UtcNow;
    }
}