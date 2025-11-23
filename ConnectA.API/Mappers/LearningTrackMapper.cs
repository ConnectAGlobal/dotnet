using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.API.Mappers;

public class LearningTrackMapper
{
    public static LearningTrack ToEntity(LearningTrackRequestDTO dto)
    {
        var learningTrack = new LearningTrack(

            dto.Name,
            dto.Description,
            dto.Level,
            dto.SeniorId,
            dto.TrackStages.Select(TrackStageMapper.ToEntity).ToList()
        );
        return learningTrack;
    }
    
    public static LearningTrackResponseDTO ToResponse(LearningTrack entity)
    {
        var response = new LearningTrackResponseDTO(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Level.ToString(),
            entity.SeniorId,
            entity.Stages.Select(TrackStageMapper.ToResponse).ToList(),
            entity.CreatedAt
        );

        return response;
    }
}