
using NSubstitute;
using Rhenus.GameChallenge.Application.Autentication;
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Infrastructure.Authentication;
using Xunit;

namespace Tests.Application.Tests;
public class AuthCommandHandlerTests
{

    [Fact]
    public void Handle_ShouldHandle_LoginPlayerCommand()
    {
        // Given
        var playerRepository = Substitute.For<IPlayerRepository>();
        var playerId = Guid.NewGuid();
        var player = Player.Create(new PlayerId(playerId), "USERNAME", 10000);
        playerRepository.GetBy(player.Username).Returns(player);
        var jwtProvider = Substitute.For<IJwtProvider>();
        var sut = new AuthCommandHanlder(playerRepository, jwtProvider);
        var command = new LoginPlayerCommand(player.Username, player.Password);

        // When
        sut.Handle(command);

        // Then
        playerRepository.Received(1).GetBy(player.Username);
        jwtProvider.Received(1).Genrate(player);
    }
}