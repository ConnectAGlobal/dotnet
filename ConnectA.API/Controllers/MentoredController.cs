using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using ConnectA.API.Hateoas;
using ConnectA.API.Mappers;
using ConnectA.Application.Pagination;
using ConnectA.Application.UseCases.Mentored;
using ConnectA.API.DTOs.Request;
using ConnectA.Domain.Enums;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/mentees/learning-tracks")]
[Produces("application/json")]
[ApiVersion(1.0)]
public class MentoredController(
    FollowLearningTrackUseCase followLearningTrackUseCase, 
    FollowLearningTrackListUseCase followLearningTrackListUseCase,
    UpdateFollowUseCase updateFollowUseCase,
    DeleteFollowUseCase deleteFollowUseCase
    ) : ControllerBase
{
    [HttpPost("follow")]
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
    
    [HttpGet("followed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFollowedLearningTracks(
        [FromQuery] Guid userId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await followLearningTrackListUseCase.GetFollowedLearningTracksAsync(userId, page, pageSize);

        var response = new PagedResultDTO<LearningTrackUserResponseDTO>
        {
            Items = result.Items.Select(LearningTrackUserMapper.ToResponse),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalItems = result.TotalItems,
            TotalPages = result.TotalPages
        };
        response.Links = PaginatedLinkBuilder.BuildPaginatedLinks("GetFollowedLearningTracks", "mentees", Url, page, pageSize, response.TotalPages);

        return Ok(response);
    }

    [HttpPut("follow/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateFollow([FromRoute] Guid id, [FromBody] LearningTrackUserUpdateRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await updateFollowUseCase.Execute(id, dto.Status, dto.Score, dto.CompletedAt);
        var response = LearningTrackUserMapper.ToResponse(updated);
        return Ok(response);
    }

    [HttpDelete("follow/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFollow([FromRoute] Guid id)
    {
        await deleteFollowUseCase.Execute(id);
        return NoContent();
    }
}