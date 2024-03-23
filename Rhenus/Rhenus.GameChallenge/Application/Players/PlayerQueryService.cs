
using Rhenus.GameChallenge.Domain.Players;

namespace Rhenus.GameChallenge.Application.Players;
public class PlayerQueryService(IPlayerRepository playerRepository)
{
    public GetPlayerQueryResponse Handle(GetPlayerQuery query)
    {
        var player = playerRepository.GetBy(new PlayerId(query.playerId));

        return new GetPlayerQueryResponse()
        {
            Username = player!.Username,
            Account = player.Account,
            Id = player.Id.Value,
            BetHistories = player.BetHistories.Select(t => new PlayerBetHistoryQueryResponseItem
            {
                Points = t.Points,
                Status = t.Status,
                Account = t.Account,
                BetId = t.BetId.Value
            }).ToList()
        };
    }
}

public record GetPlayerQuery(Guid playerId);
public record GetPlayerQueryResponse
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public int Account { get; set; }
    public IList<PlayerBetHistoryQueryResponseItem>? BetHistories { get; set; }
}

public record PlayerBetHistoryQueryResponseItem
{
    public required string Status { get; set; }
    public required string Points { get; set; }
    public int Account { get; set; }
    public Guid BetId { get; set; }
}