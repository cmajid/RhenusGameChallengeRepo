using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Domain.Bets
{
    public class Bet
    {
        public Bet(Guid id, PlayerId playerId)
        {
            Id = id;
            PlayerId = playerId;
        }

        public Guid Id { get; }
        public PlayerId PlayerId { get; }
        public int Value { get; }
    }
}