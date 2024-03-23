
using Rhenus.GameChallenge.Domain.Bets;

namespace Rhenus.GameChallenge.Domain.Players.Args;
public record PlaceBetArg(int Points, int Number, Bet Bet);