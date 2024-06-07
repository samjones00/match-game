using FluentAssertions;
using Match.Core.Interfaces;
using Match.Core.Models;
using Moq;

namespace Match.Core.UnitTests
{
    public class MatchGameTests
    {
        private Mock<IRandomProvider> _mockRandomProvider;
        private MatchGame _matchGame;

        [SetUp]
        public void SetUp()
        {
            _mockRandomProvider = new();
            _matchGame = new(_mockRandomProvider.Object);
        }

        [Test]
        public void Player1ShouldWinIfHasMoreCards()
        {
            // Arrange
            _mockRandomProvider.Setup(x => x.Shuffle(It.IsAny<Card[]>())).Returns(DeckFactory.Create(1).ToArray());
            _mockRandomProvider.Setup(x => x.Shuffle(It.IsAny<int[]>())).Returns([1, 2]);

            // Act
            var winner = _matchGame.Play(1, 1);

            // Assert
            winner.Should().Be(1);
        }

        [Test]
        public void Player2ShouldWinIfHasMoreCards()
        {
            // Arrange
            _mockRandomProvider.Setup(x => x.Shuffle(It.IsAny<Card[]>())).Returns(DeckFactory.Create(1).ToArray());
            _mockRandomProvider.Setup(x => x.Shuffle(It.IsAny<int[]>())).Returns([2, 1]);

            // Act
            var winner = _matchGame.Play(1, 1);

            // Assert
            winner.Should().Be(2);
        }

        [Test]
        public void ShouldDrawGivenPlayersHaveEqualScore()
        {
            // Arrange
            _mockRandomProvider.Setup(x => x.Shuffle(It.IsAny<Card[]>())).Returns(DeckFactory.Create(1).ToArray());
            var setup = _mockRandomProvider.SetupSequence(x => x.Shuffle(It.IsAny<int[]>()));

            Enumerable.Range(0, 12).ToList().ForEach(x => { setup.Returns([1, 2]); }); //Player 1 wins 13 times
            Enumerable.Range(0, 12).ToList().ForEach(x => { setup.Returns([2, 1]); }); //Player 2 wins 13 times

            // Act
            var winner = _matchGame.Play(1, 1);

            // Assert
            winner.Should().Be(0);
        }
    }
}