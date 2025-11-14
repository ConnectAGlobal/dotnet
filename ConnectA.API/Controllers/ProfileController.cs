using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.API.Mappers;
using ConnectA.Application.UseCases.Profiles;
using ConnectA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/profiles")]
[Produces("application/rjson")]
[ApiVersion(1.0)]
public class ProfileController(CreateProfileUseCase createProfileUseCase) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProfile([FromBody] ProfileRequestDTO dto)
    {
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var profile = ProfileMapper.ToEntity(dto);

        var createdProfile = await createProfileUseCase.CreateProfile(profile);

        var response = ProfileMapper.ToResponse(createdProfile);
        return CreatedAtAction(nameof(CreateProfile), new { id = response.Id }, response);
        
    }
}