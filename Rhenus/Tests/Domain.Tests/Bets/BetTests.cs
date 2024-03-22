using FluentAssertions;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Xunit;

namespace Tests.Domain.Tests.Bets;

public class BetTests
{
    [Fact]
    public void Constractor_ShouldCreate_NewBetInstance()
    {
        // Given
        var betId = Guid.NewGuid();
        var playerId = PlayerId.New();

        // When
        var sut = new Bet(betId, playerId);

        // Then
        sut.Id.Should().Be(betId);
        sut.PlayerId.Should().BeEquivalentTo(playerId);

        sut.Value.Should().BeInRange(0, 9);
    }
}