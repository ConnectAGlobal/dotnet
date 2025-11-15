using ConnectA.Domain.Enums;
using ConnectA.Domain.Helper;

namespace ConnectA.Domain.Entities;

public class LearningTrack
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Level Level { get; set; }
    public Guid SeniorId { get; set; }
    public User Senior { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public virtual ICollection<TrackStage> Stages { get; set; } = new List<TrackStage>();
    public virtual ICollection<LearningTrackUser> Users { get; set; } = new List<LearningTrackUser>();
    
    private LearningTrack() {}
    
    public LearningTrack(string name, string description, string level, Guid seniorId, ICollection<TrackStage> stages)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Level = TransformInEnum.ParseEnum<Level>(level);
        SeniorId = seniorId;
        CreatedAt = DateTime.UtcNow;
        AddStage(stages);
    }
    
    private void AddStage(ICollection<TrackStage> stages)
    {
        if (stages.Count < 1)
            throw new ArgumentException("A learning track must have at least one stage.");
        
        foreach (var stage in stages)
            stage.LearningTrackId = Id;
        Stages = stages;
    }
    
}