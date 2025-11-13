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
    
    private LearningTrack() {}
    
    public LearningTrack(string name, string description, string level, Guid seniorId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Level = TransformInEnum.ParseEnum<Level>(level);
        SeniorId = seniorId;
        CreatedAt = DateTime.UtcNow;
    }
    
}