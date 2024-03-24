

using Rhenus.GameChallenge.Domain.Players.Args;
using Rhenus.GameChallenge.Domain.Players.Exceptions;

namespace Rhenus.GameChallenge.Domain.Players;
public class Player
{

    private Player(CreatePlayerArg args)
    {
        if (args.Account < 0)
            throw new InvalidPlayerAccountException();

        Id = args.PlayerId;
        Username = args.Username;
        Password = args.Password;
        Account = args.Account;
    }

    public PlayerId Id { get; }
    public string Username { get; }
    public string Password { get; }
    public int Account { get; private set; }
    public IReadOnlyList<PlayerBetHistory> BetHistories => _betHistories;

    private List<PlayerBetHistory> _betHistories = new();

    public static Player Create(PlayerId playerId, string username, int account)
    {
        return new Player(new CreatePlayerArg
        {
            PlayerId = playerId,
            Username = username,
            Account = account,
            Password = string.Empty
        });
    }

    public static Player Create(CreatePlayerArg args)
    {
        return new Player(args);
    }

    public void PlaceBet(PlaceBetArg arg)
    {

        if (arg.Number is < 0 or >= 10)
        {
            throw new InvalidBetException("Invalid bet number exception");
        }

        if (arg.Points is <= 0 || arg.Points > Account)
        {
            throw new InvalidBetException("Invalid bet points exception");
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