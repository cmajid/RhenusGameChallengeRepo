namespace Rhenus.GameChallenge.Domain.Players.Exceptions;
public class InvalidBetException : ApplicationException
{
    public InvalidBetException() { }
    public InvalidBetException(string message) : base(message) { }

}