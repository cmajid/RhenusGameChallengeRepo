
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Infrastructure.Authentication;

namespace Rhenus.GameChallenge.Application.Players;
public class PlayerCommandHandler(
    IPlayerRepository playerRepository,
    IBetNumberGenerator betNumberGenerator,
    IJwtProvider jwtProvider)
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IBetNumberGenerator _betNumberGenerator = betNumberGenerator;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private const int defaultAccount = 10000;

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
            throw new Exception($"Player could not found with id: {command.PlayerId}");

        var bet = Bet.Create(BetId.New(), player.Id, _betNumberGenerator);
        var arg = new PlaceBetArg(command.Point, command.Number, bet);

        player.PlaceBet(arg);

        _playerRepository.Update(player);

        var betHistory = player.BetHistories.Last();
        return new PlaceBetCommandResult(betHistory.Account, betHistory.Status, betHistory.Points);
    }

    public string Handle(LoginPlayerCommand command)
    {

        var player = _playerRepository.GetBy(command.Username);

        if (player is null)
            throw new Exception($"Player could not found with username: {command.Username}");

        string token = _jwtProvider.Genrate(player);
        return token;
    }
}