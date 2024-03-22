
using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Application.Players;
public class PlayerCommandHandler
{
    private readonly IPlayerRepository _repository;
    private const int defaultTotalPoint = 10000;

    public PlayerCommandHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public Guid Handle(DefinePlayerCommand command)
    {
        var player = Player.Create(PlayerId.New(), command.Username, defaultTotalPoint);
        _repository.Add(player);
        return player.Id.Value;
    }
}