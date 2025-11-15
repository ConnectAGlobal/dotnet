using System.Security.Cryptography;
using System.Text;
using ConnectA.Domain.Enums;
using ConnectA.Domain.Helper;

namespace ConnectA.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public UserType Type { get; set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; set; }
    public virtual Profile Profile { get; set; }
    public virtual ICollection<LearningTrack> LearningTracksAsSenior { get; set; } = new List<LearningTrack>();
    public virtual ICollection<LearningTrackUser> LearningTracksFolows { get; set; } = new List<LearningTrackUser>();
    public virtual ICollection<MentorshipMatch> MatchesAsJunior { get; set; } = new List<MentorshipMatch>();
    public virtual ICollection<MentorshipMatch> MatchesAsSenior { get; set; } = new List<MentorshipMatch>();
    
    private User() {}
    
    public User(string name, string email, string password, string type, Profile profile)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        EncryptPassword(password);
        Type = TransformInEnum.ParseEnum<UserType>(type);
        CreatedAt = DateTime.UtcNow;
        Active = true;
        AddProfile(profile);
    }
    
    private void AddProfile(Profile profile)
    {
        Profile = profile;
        profile.SetUserId(Id);
        profile.User = this;
    }
    
    private void EncryptPassword(string password)
    {
        using var hmac = new HMACSHA512();
        PasswordSalt = Convert.ToBase64String(hmac.Key);
        PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
    
    public bool VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        using var hmac = new HMACSHA512(Convert.FromBase64String(PasswordSalt));
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var computedHashString = Convert.ToBase64String(computedHash);

        return computedHashString == PasswordHash;
    }
    
}