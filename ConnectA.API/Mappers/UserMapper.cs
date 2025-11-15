using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.API.Mappers;

public class UserMapper
{
    public static User ToEntity(UserRequestDTO dto)
    {
        var profile = ProfileMapper.ToEntity(dto.Profile);
        return new User(dto.Name, dto.Email, dto.Password, dto.Type, profile);
    }

    public static UserResponseDTO ToResponse(User user)
    {
        var profile = ProfileMapper.ToResponse(user.Profile);
        return new UserResponseDTO(user.Id, user.Name, user.Email, user.Type.ToString(), user.CreatedAt, user.Active, profile);
    }
}