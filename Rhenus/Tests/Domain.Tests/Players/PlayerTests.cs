
using FluentAssertions;
using NSubstitute;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Domain.Players.Args;
using Rhenus.GameChallenge.Domain.Players.Exceptions;
using Xunit;

namespace Tests.Domain.Tests.Players
{
    public class PlayerTests
    {

        #region Constractor Tests
        [Fact]
        public void Constractor_ShouldCreate_NewPlayerInstance()
        {
            // Given
            var playerId = PlayerId.New();
            var username = "USERNAME";
            var account = 10000;

            // When
            var sut = Player.Create(playerId, username, account);

            // Then
            sut.Id.Should().Be(playerId);
            sut.Username.Should().Be(username);
            sut.Account.Should().Be(account);
        }

        [Fact]
        public void Constractor_ShouldThrowException_WhenAccountIsLessThanZiro()
        {
            // Given
            var playerId = PlayerId.New();
            var username = "USERNAME";
            var account = -1;

            // When
            var act = () =>
            {
                Player.Create(playerId, username, account);
            };

            // Then
            act.Should().Throw<InvalidPlayerAccountException>();
        }

        #endregion

        #region Place Bet Tests
        [Fact]
        public void PlaceBet_IncreasesAccount_WhenPlayerHasPredictedCorrectly()
        {
            // Given
            var sut = Player.Create(PlayerId.New(), "USERNAME", 10000);
            var genrator = Substitute.For<IBetNumberGenerator>();
            genrator.Generate().Returns(6);
            var bet = Bet.Create(BetId.New(), sut.Id, genrator);
            var arg = new PlaceBetArg(100, 6, bet);

            // When
            sut.PlaceBet(arg);

            // Then
            sut.Account.Should().Be(10900);
        }

        [Fact]
        public void PlaceBet_DecreasesAccount_WhenPlayerHasPredictedWrongly()
        {
            // Given
            var sut = Player.Create(PlayerId.New(), "USERNAME", 10000);
            var genrator = Substitute.For<IBetNumberGenerator>();
            genrator.Generate().Returns(6);
            var bet = Bet.Create(BetId.New(), sut.Id, genrator);
            var arg = new PlaceBetArg(100, 5, bet);

            // When
            sut.PlaceBet(arg);

            // Then
            sut.Account.Should().Be(9900);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(10)]
        [InlineData(11)]
        public void PlaceBet_ShouldThrowException_WhenPredictionNumberIsNotInRangeOf_0_9(int number)
        {
            // Given
            var sut = Player.Create(PlayerId.New(), "USERNAME", 10000);
            var genrator = Substitute.For<IBetNumberGenerator>();
            var bet = Bet.Create(BetId.New(), sut.Id, genrator);
            var arg = new PlaceBetArg(100, number, bet);

            // When
            var act = () =>
            {
                sut.PlaceBet(arg);
            };

            // Then
            act.Should().Throw<InvalidBetNumberException>();
        }

        [Fact]
        public void PlaceBet_Fills_BetHistory()
        {
            // Given
            var sut = Player.Create(PlayerId.New(), "USERNAME", 10000);
            var genrator = Substitute.For<IBetNumberGenerator>();
            genrator.Generate().Returns(6);
            var bet = Bet.Create(BetId.New(), sut.Id, genrator);
            var arg = new PlaceBetArg(100, 6, bet);

            // When
            sut.PlaceBet(arg);

            // Then
            sut.BetHistories.Should().ContainEquivalentOf(
                    new PlayerBetHistory("won", "+900", 10900, bet.Id));
        }

        #endregion
    }
}