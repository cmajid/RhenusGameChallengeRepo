
using FluentAssertions;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Infrastructure.Repositories;
using Xunit;

namespace Tests.Repository.Tests;
public class InMemoryPlayerRepositoryTests
{
    [Fact]
    public void Add_GetBy_SendCorrectPlayer_ShouldReturnPlayer()
    {
        // Given
        var playerId = Guid.NewGuid();
        var player = Player.Create(new PlayerId(playerId), "USERNAME", 10000);
        var sut = new InMemoryPlayerRepository();
        // When
        sut.Add(player);

        // Then
        sut.GetBy(player.Username).Should().Be(player);
        sut.GetBy(player.Id).Should().Be(player);
    }
}