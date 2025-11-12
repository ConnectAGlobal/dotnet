using Asp.Versioning;
using ConnectA.API.DTOs.Request;
using ConnectA.Application.Mappers;
using ConnectA.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[Produces("application/json")]
[ApiVersion(1.0)]
public class UserController(
        CreateUserUseCase createUserUseCase
    ) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var user = UserMapper.ToEntity(dto);
        Console.Write("Teste");
        var createdUser = await createUserUseCase.CreateUser(user);
        var response = UserMapper.ToResponse(createdUser);
        return CreatedAtAction(nameof(CreateUser), new { id = response.Id }, response);
    }
}