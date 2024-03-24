
using Microsoft.AspNetCore.Mvc;
using Rhenus.GameChallenge.Application.Autentication;
using Rhenus.GameChallenge.Application.Autentication.Commands;

namespace Rhenus.GameChallenge.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthCommandHanlder handler) : ControllerBase
{

    [HttpPost("register")]
    public IActionResult Register(RegisterPlayerCommand command)
    {
        handler.Handle(command);
        return Created();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginPlayerCommand command)
    {
        var result = handler.Handle(command);
        return Ok(result);
    }
}