
using System.ComponentModel.DataAnnotations;

namespace Rhenus.GameChallenge.Application.Autentication.Commands;
public record RegisterPlayerCommand
{
    public RegisterPlayerCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }

    [Required]
    public string Password { get; private set; }

    [Required]
    public string Username { get; private set; }
}