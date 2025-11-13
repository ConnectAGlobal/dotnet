namespace ConnectA.API.DTOs.Response;

public class UserResponseDTO(Guid id, string name, string email, string type, DateTime createdAt, bool active)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Type { get; init; } = type;
    public DateTime CreatedAt { get; init; } = createdAt;
    public bool Active { get; init; } = active;
}