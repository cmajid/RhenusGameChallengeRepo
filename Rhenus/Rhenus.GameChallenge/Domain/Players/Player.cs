

using Rhenus.GameChallenge.Domain.Players.Exceptions;

namespace Rhenus.GameChallenge.Domain.Players;
public class Player
{

    private Player(PlayerId playerId, string username, int account)
    {
        if (account < 0)
            throw new InvalidPlayerAccountException();

        Id = playerId;
        Username = username;
        Account = account;
    }

    public PlayerId Id { get; }
    public string Username { get; }
    public int Account { get; private set; }
    public IReadOnlyList<PlayerBetHistory> BetHistories => _betHistories;

    private List<PlayerBetHistory> _betHistories = new();

    public static Player Create(PlayerId playerId, string username, int account)
    {
        return new Player(playerId, username, account);
    }

    public void PlaceBet(PlaceBetArg arg)
    {

        if (arg.Number is < 0 or >= 10)
        {
            throw new InvalidBetNumberException();
        }

        PlayerBetHistory? history = default;
        if (arg.Number == arg.Bet.Number)
        {
            var points = arg.Points * 9;
            Account += points;
            history = new("won", $"+{points}", Account, arg.Bet.Id);
        }
        else
        {
            Account -= arg.Points;
            history = new("lost", $"-{arg.Points}", Account, arg.Bet.Id);
        }
        _betHistories.Add(history);
    }
}