
namespace Rhenus.GameChallenge.Domain.Players.Args;

public record CreatePlayerArg
{
    public required PlayerId PlayerId { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
    public int Account { get; set; }
}
