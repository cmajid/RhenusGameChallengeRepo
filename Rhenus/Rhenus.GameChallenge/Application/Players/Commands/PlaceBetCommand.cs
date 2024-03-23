
using System.Text.Json.Serialization;

namespace Rhenus.GameChallenge.Application.Players.Commands;
public record PlaceBetCommand
{
    public PlaceBetCommand(int number, int point, Guid playerId)
    {
        Number = number;
        Point = point;
        PlayerId = playerId;
    }
    [JsonIgnore] public Guid PlayerId { get; set; }
    public int Number { get; set; }
    public int Point { get; set; }

}
public record PlaceBetCommandResult(int Account, string Status, string Points, int BetNumber);