using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.Mappers;

public class UserMapper
{
    public static User ToEntity(UserRequestDTO dto)
    {
        return new User(dto.Name, dto.Email, dto.Password, dto.Type);
    }

    public static UserResponseDTO ToResponse(User user)
    {
        return new UserResponseDTO(user.Id, user.Name, user.Email, user.Type.ToString(), user.CreatedAt, user.Active);
    }
}