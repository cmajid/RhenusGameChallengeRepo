using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Domain.Bets
{
    public class Bet
    {
        private Bet()
        {
         
        }

        private Bet(BetId id, PlayerId playerId,IBetValueGenerator betValueGenerator)
        {
            Id = id;
            PlayerId = playerId;
            Value = betValueGenerator.Generate();
        }

        public static Bet Create(BetId id, PlayerId playerId, IBetValueGenerator betValueGenerator){
          return new Bet(id, playerId,betValueGenerator);
        }
        public BetId Id { get; }
        public PlayerId PlayerId { get; }
        public int Value { get; }
    }
}