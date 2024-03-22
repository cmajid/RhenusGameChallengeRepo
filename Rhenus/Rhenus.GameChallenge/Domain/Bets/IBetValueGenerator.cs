namespace Rhenus.GameChallenge.Domain.Bets;
public interface IBetValueGenerator
{
    int Generate();
}

public class BetValueGenerator : IBetValueGenerator
{
    public int Generate()
    {
        Random rand = new();
        int randomNumber = rand.Next(0, 10);
        return randomNumber;
    }
}