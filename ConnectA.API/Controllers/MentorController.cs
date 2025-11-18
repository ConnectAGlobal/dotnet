using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.API.Mappers;
using ConnectA.Application.UseCases.Mentor;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/mentors")]
[Produces("application/json")]
[ApiVersion(1.0)]
public class MentorController(
        CreateLearningTrackUseCase createLearningTrackUseCase,
        AddTrackStageUseCase addTrackStageUseCase
    ) : ControllerBase
{
    [HttpPost("learning-tracks")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateLearningTrack([FromBody] LearningTrackRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var learningTrack = LearningTrackMapper.ToEntity(dto);
        var createdLearningTrack = await createLearningTrackUseCase.CreateLearningTrack(learningTrack);
        var response = LearningTrackMapper.ToResponse(createdLearningTrack);
        return CreatedAtAction(nameof(CreateLearningTrack), new { id = response.Id }, response);
    }
    
    [HttpPost("{learningTrackId:guid}/stages")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddTrackStage([FromRoute] Guid learningTrackId, [FromBody] TrackStageRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var trackStage = TrackStageMapper.ToEntity(dto);
        var createdTrackStage = await addTrackStageUseCase.AddTrackStage(learningTrackId, trackStage);
        var response = TrackStageMapper.ToResponse(createdTrackStage);
        return CreatedAtAction(nameof(AddTrackStage), new { learningTrackId = learningTrackId, id = response.Id }, response);
    }
    
    
    
}