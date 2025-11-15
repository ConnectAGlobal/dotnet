namespace ConnectA.Domain.Entities;

public class Profile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Biography { get; set; }
    public string Skills { get; set; }
    public string Experience { get; set; }
    public string Objectives { get; set; }
    public string Location { get; set; }
    public string Lenguages { get; set; }
    
    private Profile() {}
    
    public Profile(string biography, string skills, string experience, string objectives, string location, string lenguages)
    {
        Id = Guid.NewGuid();
        Biography = biography;
        Skills = skills;
        Experience = experience;
        Objectives = objectives;
        Location = location;
        Lenguages = lenguages;
    }
    
    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
    
}