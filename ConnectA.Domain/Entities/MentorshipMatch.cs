namespace ConnectA.Domain.Entities;

public class MentorshipMatch
{
    public Guid Id { get; set; }
    public Guid JuniorId { get; set; }
    public Guid SeniorId { get; set; }

    public double CompatibilityScore { get; set; }
    public DateTime MatchedAt { get; set; }
    
    public virtual User Junior { get; set; } 
    public virtual User Senior { get; set; } 
    public virtual ICollection<MentorshipChallenge> Challenges { get; set; } = new List<MentorshipChallenge>();
    public virtual ICollection<MentorshipEvaluation> Evaluations { get; set; } = new List<MentorshipEvaluation>();
    
    private MentorshipMatch() {}
    
    public MentorshipMatch(Guid juniorId,  Guid seniorId, double compatibilityScore)
    {
        Id = Guid.NewGuid();
        JuniorId = juniorId;
        SeniorId = seniorId;
        CompatibilityScore = compatibilityScore;
        MatchedAt = DateTime.UtcNow;
    }
}