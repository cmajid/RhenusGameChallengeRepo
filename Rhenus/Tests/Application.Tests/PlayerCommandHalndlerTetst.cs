
using NSubstitute;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Xunit;

namespace Tests.Application.Tests;
public class PlayerCommandHalndlerTetst
{
    [Fact]
    public void Handle_ShouldHandle_DefinePlayerCommand()
    {
        // Given
        var playerRepository = Substitute.For<IPlayerRepository>();
        var betNumberGenerator = Substitute.For<IBetNumberGenerator>();
        var sut = new PlayerCommandHandler(playerRepository, betNumberGenerator);
        var command = new DefinePlayerCommand("USERNAME");

        // When
        sut.Handle(command);

        // Then
        playerRepository.Received(1).Add(Arg.Any<Player>());
    }

    [Fact]
    public void Handle_ShouldHandle_PlaceBetCommand()
    {
        // Given
        var betNumberGenerator = Substitute.For<IBetNumberGenerator>();
        var playerId = Guid.NewGuid();
        var player = Player.Create(new PlayerId(playerId), "USERNAME", 10000);
        var playerRepository = Substitute.For<IPlayerRepository>();
        playerRepository.GetBy(player.Id).Returns(player);
        var sut = new PlayerCommandHandler(playerRepository, betNumberGenerator);
        var command = new PlaceBetCommand(1, 100, playerId);

        // When
        sut.Handle(command);

        // Then
        playerRepository.Received(1).GetBy(player.Id);
        playerRepository.Received(1).Update(player);
    }
}