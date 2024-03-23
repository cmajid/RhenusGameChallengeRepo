
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Infrastructure.Authentication;

namespace Rhenus.GameChallenge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(PlayerCommandHandler handler) : ControllerBase
{

    [HttpPost]
    public IActionResult Login(LoginPlayerCommand command)
    {
        var result = handler.Handle(command);
        return Ok(result);
    }
}