
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Application.Players;
public class PlayerCommandHandler
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IBetNumberGenerator _betNumberGenerator;
    private const int defaultAccount = 10000;

    public PlayerCommandHandler(IPlayerRepository playerRepository, IBetNumberGenerator betNumberGenerator)
    {
        _playerRepository = playerRepository;
        _betNumberGenerator = betNumberGenerator;
    }

    public Guid Handle(DefinePlayerCommand command)
    {
        var player = Player.Create(PlayerId.New(), command.Username, defaultAccount);
        _playerRepository.Add(player);
        return player.Id.Value;
    }

    public PlaceBetCommandResult Handle(PlaceBetCommand command)
    {
        var player = _playerRepository.GetBy(new PlayerId(command.PlayerId));
        if (player is null)
        {
            return default;
        }

        var bet = Bet.Create(BetId.New(), player.Id, _betNumberGenerator);
        var arg = new PlaceBetArg(command.Point, command.Number, bet);

        player.PlaceBet(arg);

        _playerRepository.Update(player);
        return default;

    }

}