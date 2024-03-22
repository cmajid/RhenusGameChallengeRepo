
namespace Rhenus.GameChallenge.Application.Players.Commands;
public record PlaceBetCommand(int Number, int Point, Guid PlayerId);
public record PlaceBetCommandResult(int Account, string Status, string Points);