using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.Domain.Entities;

namespace ConnectA.API.Mappers;

public class TrackStageMapper
{
    public static TrackStage ToEntity(TrackStageRequestDTO dto)
    {
        var trackStage = new TrackStage(
            dto.Title,
            dto.Description,
            dto.ActivityType,
            dto.Order,
            dto.EstimatedDuration,
            dto.ResourceLink
        );

        return trackStage;
    }
    
    public static TrackStageResponseDTO ToResponse(TrackStage entity)
    {
        var response = new TrackStageResponseDTO()
        {
            Id =  entity.Id,
            LearningTrackId = entity.LearningTrackId,
            Title = entity.Title,
            Description = entity.Description,
            ActivityType = entity.ActivityType.ToString(),
            Order = entity.Order,
            EstimatedDuration = entity.EstimatedDuration,
            ResourceLink = entity.ResourceLink
        };

        return response;
    }
}