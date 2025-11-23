using Asp.Versioning;
using ConnectA.Application.UseCases.Matching;
using Microsoft.AspNetCore.Mvc;

namespace ConnectA.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/matchs")]
[Produces("application/json")]
[ApiVersion(2.0)]
public class MatchController(
    GenerateMatchUseCase generateMatchUseCase
    ) : ControllerBase
{
    [HttpPost("match")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateMatch()
    {
        await generateMatchUseCase.GenerateMatch();
        return Ok("Match generation process started.");
    }
}