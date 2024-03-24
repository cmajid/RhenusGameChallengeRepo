
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Rhenus.GameChallenge.Domain.Players.Exceptions;

namespace Rhenus.GameChallenge.Application.Players.Commands;
public record PlaceBetCommand
{
    public PlaceBetCommand(int number, int point, Guid playerId)
    {
        Number = number;
        PlayerId = playerId;
        Point = point;
    }

    [JsonIgnore]
    public Guid PlayerId { get; set; }

    public int Number { get; private set; }

    public int Point { get; private set; }

}
public record PlaceBetCommandResult(int Account, string Status, string Points, int BetNumber);