
using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Infrastructure.Authentication;
public interface IJwtProvider
{
    string Genrate(Player player);
}
