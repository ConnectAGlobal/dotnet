namespace ConnectA.API.DTOs.Request;

public class UserRequestDTO(string name, string email, string password, string type, ProfileRequestDTO profile)
{
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public string Type { get; init; } = type;
    public ProfileRequestDTO Profile = profile;
}