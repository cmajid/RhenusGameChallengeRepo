using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Infrastructure.Repositories;
public class InMemoryPlayerRepository : IPlayerRepository
{
    private static Dictionary<PlayerId, Player> _players = new();
    public void Add(Player player)
    {
        _players.Add(player.Id, player);
    }

    public Player? GetBy(PlayerId id)
    {
        if (!_players.ContainsKey(id))
            return null;

        return _players[id];
    }

    public Player? GetBy(string username)
    {
        return _players.FirstOrDefault(t=> t.Value.Username == username).Value;
    }

    public void Update(Player player)
    {
        _players[player.Id] = player;
    }
}