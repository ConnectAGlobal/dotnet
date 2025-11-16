using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.API.Mappers;
using ConnectA.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[Produces("application/json")]
[ApiVersion(1.0)]
public class UserController(
        CreateUserUseCase createUserUseCase,
        EditProfileUseCase editProfileUseCase
    ) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var user = UserMapper.ToEntity(dto);
        var createdUser = await createUserUseCase.CreateUser(user);
        var response = UserMapper.ToResponse(createdUser);
        return CreatedAtAction(nameof(CreateUser), new { id = response.Id }, response);
    }
    
    [HttpPatch("/edit-profile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EditProfile([FromQuery] Guid userId, [FromBody] ProfileRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var profile = ProfileMapper.ToEntity(dto);
        var updatedUser = await editProfileUseCase.EditProfile(userId, profile);
        var response = UserMapper.ToResponse(updatedUser);
        return Ok(response);
    }
}