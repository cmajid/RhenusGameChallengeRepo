
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;

namespace Rhenus.GameChallenge.Controllers; 


[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly PlayerCommandHandler _handler;

    public PlayersController(PlayerCommandHandler handler)
    {
        _handler = handler;
    }
   
    [HttpPost]
    public IActionResult Post(PlaceBetCommand command)
    {
        var result = _handler.Handle(command);
        return Ok(result);
    }
}