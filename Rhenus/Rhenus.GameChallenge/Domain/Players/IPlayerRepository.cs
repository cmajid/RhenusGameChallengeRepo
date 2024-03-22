
namespace Rhenus.GameChallenge.Domain.Players;

public interface IPlayerRepository
{
    Player? GetBy(PlayerId id);
    void Add(Player player);
    void Update(Player player);
}