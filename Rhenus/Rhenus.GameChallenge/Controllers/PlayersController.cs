
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;

namespace Rhenus.GameChallenge.Controllers;

[Authorize]
[ApiController]
[Route("api/players")]
public class PlayersController(
    PlayerCommandHandler commandHandler,
    PlayerQueryService queryHandler,
    IHttpContextAccessor httpContextAccessor)
    : ControllerBase
{

    [HttpPost]
    public IActionResult Post(PlaceBetCommand command)
    {
        command.PlayerId = GetCurrentUser();
        var result = commandHandler.Handle(command);
        return Ok(result);
    }

    [HttpGet()]
    public IActionResult Get()
    {
        var query = new GetPlayerQuery(GetCurrentUser());
        return Ok(queryHandler.Handle(query));
    }

    private Guid GetCurrentUser() =>
         Guid.Parse(httpContextAccessor
                        .HttpContext!.User
                        .FindFirstValue(ClaimTypes.NameIdentifier)!);
}