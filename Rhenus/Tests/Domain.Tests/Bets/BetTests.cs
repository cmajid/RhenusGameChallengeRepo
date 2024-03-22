using FluentAssertions;
using NSubstitute;
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
        var betId = BetId.New();
        var playerId = PlayerId.New();
        var genrator = Substitute.For<IBetNumberGenerator>();

        // When
        var sut = Bet.Create(betId, playerId, genrator);

        // Then
        sut.Id.Should().Be(betId);
        sut.PlayerId.Should().BeEquivalentTo(playerId);
        sut.Number.Should().BeInRange(0, 9);
    }

    [Fact]
    public void Constractor_ShouldCreateValueWithValidRangeOf0_9()
    {
          // Given
        var betId = BetId.New();
        var playerId = PlayerId.New();
        var genrator = Substitute.For<IBetNumberGenerator>();
        genrator.Generate().Returns(7);

        // When
        var sut = Bet.Create(betId, playerId, genrator);

        // Then
        sut.Id.Should().Be(betId);
        sut.PlayerId.Should().BeEquivalentTo(playerId);
        sut.Number.Should().Be(7);
    }
}