namespace Rhenus.GameChallenge.Domain.Bets;

public interface IBetRepository
{
    Bet GetBy(BetId id);
    void Add(Bet bet);
}