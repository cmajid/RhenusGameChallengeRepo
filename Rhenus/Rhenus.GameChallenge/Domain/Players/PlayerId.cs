namespace Rhenus.GameChallenge.Domain.Players;

public class PlayerId
{
    private PlayerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static PlayerId New()
    {
        return new PlayerId(Guid.NewGuid());
    }
}
