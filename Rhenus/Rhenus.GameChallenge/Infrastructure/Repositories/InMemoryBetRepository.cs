
using Rhenus.GameChallenge.Domain.Bets;

namespace Rhenus.GameChallenge.Infrastructure.Repositories;
public class InMemoryBetRepository : IBetRepository
{
    private static Dictionary<BetId, Bet> _bets = new();

    public void Add(Bet bet)
    {
        _bets.Add(bet.Id, bet);
    }

    public Bet GetBy(BetId id)
    {
        return _bets[id];
    }
}