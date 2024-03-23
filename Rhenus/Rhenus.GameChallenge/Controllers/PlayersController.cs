
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;

namespace Rhenus.GameChallenge.Controllers; 

[Authorize]
[ApiController]
[Route("api/players")]
public class PlayersController(PlayerCommandHandler commandHandler, PlayerQueryService queryHandler) : ControllerBase
{

    [HttpPost]
    public IActionResult Post(PlaceBetCommand command)
    {
        command.PlayerId = getCurrentUser();
        var result = commandHandler.Handle(command);
        return Ok(result);
    }


    [HttpGet()]
    public IActionResult Get( ){
        var playerId = getCurrentUser();
        var query = new GetPlayerQuery(playerId);
        return Ok(queryHandler.Handle(query));  
    }


    private Guid getCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var playerId = identity!.FindFirst(ClaimTypes.NameIdentifier);
        return Guid.Parse(playerId!.Value);
    }
}