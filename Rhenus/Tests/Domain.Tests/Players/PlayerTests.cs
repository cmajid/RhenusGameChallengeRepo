
using FluentAssertions;
using Rhenus.GameChallenge.Domain.Players;
using Xunit;

namespace Tests.Domain.Tests.Players
{
    public class PlayerTests
    {
        
        [Fact]
        public void Constractor_ShouldCreate_NewPlayerInstance()
        {
            // Given
            var playerId = PlayerId.New();
            var username = "USERNAME";
            var totalPoint = 10000;
            
            // When
            var sut = Player.Create(playerId, username, totalPoint);

            // Then
            sut.Id.Should().Be(playerId);
            sut.Username.Should().Be(username);
            sut.TotalPoint.Should().Be(totalPoint);
        }
    }
}