
namespace Rhenus.GameChallenge.Domain.Players;

public interface IPlayerRepository
{
    Player? GetBy(PlayerId id);
    Player? GetBy(string username);
    void Add(Player player);
    void Update(Player player);
}