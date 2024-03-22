

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

        if (arg.Number == arg.Bet.Number)
        {
            Account += arg.Points * 9;
        }
        else
        {
            Account -= arg.Points;
        }
    }
}