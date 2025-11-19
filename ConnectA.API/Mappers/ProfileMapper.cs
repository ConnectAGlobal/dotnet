using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.API.Mappers;

public class ProfileMapper
{
    public static Profile ToEntity(ProfileRequestDTO dto)
    {
        return new Profile(dto.Biography, dto.Skills, dto.Experience, dto.Objectives, dto.Location, dto.Lenguages);
    }
    
    public static ProfileResponseDTO? ToResponse(Profile? profile)
    {
        if (profile == null)
            return null;

        return new ProfileResponseDTO(
            profile.Id,
            profile.UserId,
            profile.Biography,
            profile.Skills,
            profile.Experience,
            profile.Objectives,
            profile.Location,
            profile.Lenguages
        );
    }
}