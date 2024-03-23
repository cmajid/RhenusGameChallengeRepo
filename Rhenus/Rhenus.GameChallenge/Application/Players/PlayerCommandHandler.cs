
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Domain.Players.Args;
using Rhenus.GameChallenge.Infrastructure.Authentication;

namespace Rhenus.GameChallenge.Application.Players;
public class PlayerCommandHandler(
    IPlayerRepository playerRepository,
    IBetNumberGenerator betNumberGenerator)
{

    private const int defaultAccountValue = 10000;

    public Guid Handle(DefinePlayerCommand command)
    {
        var player = Player.Create(PlayerId.New(), command.Username, defaultAccountValue);
        playerRepository.Add(player);
        
        return player.Id.Value;
    }

    public PlaceBetCommandResult Handle(PlaceBetCommand command)
    {
        var player = playerRepository.GetBy(new PlayerId(command.PlayerId));
        if (player is null)
            throw new Exception($"Player could not found with id: {command.PlayerId}");

        var bet = Bet.Create(BetId.New(), player.Id, betNumberGenerator);
        var arg = new PlaceBetArg(command.Point, command.Number, bet);
        player.PlaceBet(arg);
        playerRepository.Update(player);
        var betHistory = player.BetHistories.Last();

        return new PlaceBetCommandResult(betHistory.Account, betHistory.Status, betHistory.Points, bet.Number);
    }

}