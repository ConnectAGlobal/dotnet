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
        CreateLearningTrackUseCase createLearningTrackUseCase
    ) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateLearningTrack(LearningTrackRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var learningTrack = LearningTrackMapper.ToEntity(dto);
        var createdLearningTrack = await createLearningTrackUseCase.CreateLearningTrack(learningTrack);
        var response = LearningTrackMapper.ToResponse(createdLearningTrack);
        return CreatedAtAction(nameof(CreateLearningTrack), new { id = response.Id }, response);
        
    }
}