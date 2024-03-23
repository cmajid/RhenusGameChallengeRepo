
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;

namespace Rhenus.GameChallenge.Controllers; 

[Authorize]
[ApiController]
[Route("api/players")]
public class PlayersController(PlayerCommandHandler handler) : ControllerBase
{

    [HttpPost]
    public IActionResult Post(PlaceBetCommand command)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var playerId = identity!.FindFirst(ClaimTypes.NameIdentifier);
        command.PlayerId = Guid.Parse(playerId!.Value);
        var result = handler.Handle(command);
        return Ok(result);
    }
}