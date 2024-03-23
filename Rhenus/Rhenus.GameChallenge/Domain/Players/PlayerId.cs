namespace Rhenus.GameChallenge.Domain.Players;

public class PlayerId :IEquatable<PlayerId>
{
    public PlayerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static PlayerId New()
    {
        return new PlayerId(Guid.NewGuid());
    }

 public bool Equals(PlayerId? other)
    {
        if (other is null)
            return false;

        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is PlayerId otherId)
            return Equals(otherId);
        else
            return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(PlayerId left, PlayerId right)
    {
        if (left is null)
            return right is null;
        
        return left.Equals(right);
    }

    public static bool operator !=(PlayerId left, PlayerId right)
    {
        return !(left == right);
    }
}
