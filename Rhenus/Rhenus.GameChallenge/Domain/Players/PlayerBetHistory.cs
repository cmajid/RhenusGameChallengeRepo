using Rhenus.GameChallenge.Domain.Bets;

namespace Rhenus.GameChallenge.Domain.Players;
public class PlayerBetHistory
{
    public PlayerBetHistory(string status, string points, int account, BetId betId)
    {
        Status = status;
        Points = points;
        Account = account;
        BetId = betId;
    }

    public string Status { get; }
    public string Points { get; }
    public int Account { get; }
    public BetId BetId { get; }
}
