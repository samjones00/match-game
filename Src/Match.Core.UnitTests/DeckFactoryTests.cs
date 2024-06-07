using FluentAssertions;
using Match.Core.Enums;
using Match.Core.Models;

namespace Match.Core.UnitTests;

public class DeckFactoryTests
{
    [TestCase(1, 52)]
    [TestCase(2, 104)]
    [TestCase(3, 156)]
    public void ShouldCreateDeck(int packQuantity, int expectedCards)
    {
        // Arrange & Act
        var deck = DeckFactory.Create(packQuantity);

        OutputCards(deck);

        // Assert
        deck.Count().Should().Be(expectedCards);
    }

    [Test]
    public void ShouldUseCorrectSuitSymbols()
    {
        // Arrange & Act
        var deck = DeckFactory.Create(1);

        // Assert
        deck.First(x => x.Suit == Suit.Clubs.ToString()).Symbol.Should().Be("♣");
        deck.First(x => x.Suit == Suit.Diamonds.ToString()).Symbol.Should().Be("♦");
        deck.First(x => x.Suit == Suit.Hearts.ToString()).Symbol.Should().Be("♥");
        deck.First(x => x.Suit == Suit.Spades.ToString()).Symbol.Should().Be("♠");
    }

    [Test]
    public void ShouldAddCorrectValues()
    {
        // Arrange & Act
        var deck = DeckFactory.Create(1);

        // Assert
        deck.Count(x => x.Value == CardValue.Ace).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Two).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Three).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Four).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Five).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Six).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Seven).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Eight).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Nine).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Ten).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Jack).Should().Be(4);
        deck.Count(x => x.Value == CardValue.Queen).Should().Be(4);
        deck.Count(x => x.Value == CardValue.King).Should().Be(4);
    }

    [Test]
    public void ShouldAddCorrectSuits()
    {
        // Arrange & Act
        var deck = DeckFactory.Create(1);

        // Assert
        deck.Count(x => x.Suit == Suit.Clubs.ToString()).Should().Be(deck.Count() / 4);
        deck.Count(x => x.Suit == Suit.Diamonds.ToString()).Should().Be(deck.Count() / 4);
        deck.Count(x => x.Suit == Suit.Hearts.ToString()).Should().Be(deck.Count() / 4);
        deck.Count(x => x.Suit == Suit.Spades.ToString()).Should().Be(deck.Count() / 4);
    }

    private static void OutputCards(IEnumerable<Card> deck)
    {
        foreach (var card in deck)
        {
            TestContext.Out.WriteLine(card);
        }
    }
}