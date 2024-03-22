namespace Rhenus.GameChallenge.Domain.Bets;
public interface IBetNumberGenerator
{
    int Generate();
}

public class BetNumberGenerator : IBetNumberGenerator
{
    public int Generate()
    {
        Random rand = new();
        int randomNumber = rand.Next(0, 10);
        return randomNumber;
    }
}