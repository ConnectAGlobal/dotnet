using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.API.Mappers;

public class LearningTrackUserMapper
{
    public static LearningTrackUser ToEntity(LearningTrackUserRequestDTO dto)
    {
        var learningTrackUser = new LearningTrackUser(dto.UserId, dto.LearningTrackId);
        return learningTrackUser;
    }
    
    public static LearningTrackUserResponseDTO ToResponse(LearningTrackUser entity)
    {
        var response = new LearningTrackUserResponseDTO(
            entity.Id,
            entity.UserId,
            entity.LearningTrackId,
            entity.Status,
            entity.Score,
            entity.StartedAt,
            entity.CompletedAt
        );

        return response;
    }
}