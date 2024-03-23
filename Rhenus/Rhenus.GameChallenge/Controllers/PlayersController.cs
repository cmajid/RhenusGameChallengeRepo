
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;

namespace Rhenus.GameChallenge.Controllers; 

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PlayersController(PlayerCommandHandler handler) : ControllerBase
{

    [HttpPost]
    public IActionResult Post(PlaceBetCommand command)
    {
        var result = handler.Handle(command);
        return Ok(result);
    }
}