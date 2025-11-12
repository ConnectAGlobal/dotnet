namespace ConnectA.API.DTOs.Response;

public class UserResponseDTO(Guid id, string name, string email, string type, DateTime createdAt, bool active)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Type { get; set; } = type;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = active;
}