using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.API.Mappers;
using ConnectA.Application.UseCases.Mentored;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/mentees")]
[Produces("application/json")]
[ApiVersion(1.0)]
public class MentoredController(
    FollowLearningTrackUseCase followLearningTrackUseCase
    ) : ControllerBase
{
    [HttpPost("learning-tracks/follow")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> FollowLearningTrack([FromBody] LearningTrackUserRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var learningTrackUser = LearningTrackUserMapper.ToEntity(dto);
        var createdLearningTrackUser = await followLearningTrackUseCase.FollowLearningTrack(learningTrackUser);
        var responseDto = LearningTrackUserMapper.ToResponse(createdLearningTrackUser);
        return CreatedAtAction(nameof(FollowLearningTrack), new { id = createdLearningTrackUser.Id }, responseDto);
    }
}