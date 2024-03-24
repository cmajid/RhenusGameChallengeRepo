
using System.ComponentModel.DataAnnotations;

namespace Rhenus.GameChallenge.Application.Players.Commands;
public record DefinePlayerCommand
{

    public DefinePlayerCommand(string username)
    {
        Username = username;
    }

    [Required]
    public string Username { get; private set; }
}
