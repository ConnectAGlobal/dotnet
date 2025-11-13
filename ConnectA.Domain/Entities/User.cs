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
    public Profile Profile { get; set; }
    
    private User() {}
    
    public User(string name, string email, string password, string type)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        EncryptPassword(password);
        Type = TransformInEnum.ParseEnum<UserType>(type);
        CreatedAt = DateTime.UtcNow;
        Active = true;
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