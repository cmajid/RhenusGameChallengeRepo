using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Domain.Bets
{
    public class Bet
    {
        private Bet()
        {
         
        }

        private Bet(BetId id, PlayerId playerId,IBetNumberGenerator betNumberGenerator)
        {
            Id = id;
            PlayerId = playerId;
            Number = betNumberGenerator.Generate();
        }

        public static Bet Create(BetId id, PlayerId playerId, IBetNumberGenerator betNumberGenerator){
          return new Bet(id, playerId,betNumberGenerator);
        }
        public BetId Id { get; }
        public PlayerId PlayerId { get; }
        public int Number { get; }
    }
}