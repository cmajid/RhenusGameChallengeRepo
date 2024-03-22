namespace Rhenus.GameChallenge.Domain.Bets;

public class BetId
{
    private BetId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static BetId New()
    {
        return new BetId(Guid.NewGuid());
    }
}
