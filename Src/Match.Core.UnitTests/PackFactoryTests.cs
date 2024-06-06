using FluentAssertions;
using Match.Core.Enums;
using Match.Core.Models;

namespace Match.Core.UnitTests;

public class Tests
{
    [TestCase(1, 52)]
    [TestCase(2, 104)]
    [TestCase(3, 156)]
    public void ShouldCreateDeck(int packQuantity, int expectedCards)
    {
        var deck = PackFactory.CreateDeck(packQuantity);

        OutputCards(deck);

        deck.Count().Should().Be(expectedCards);
        deck.Count(x => x.Suit == Suit.Clubs.ToString()).Should().Be(expectedCards / 4);
        deck.Count(x => x.Suit == Suit.Diamonds.ToString()).Should().Be(expectedCards / 4);
        deck.Count(x => x.Suit == Suit.Hearts.ToString()).Should().Be(expectedCards / 4);
        deck.Count(x => x.Suit == Suit.Spades.ToString()).Should().Be(expectedCards / 4);

        deck.Count(x=>x.Value == CardValue.Ace).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Two).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Three).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Four).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Five).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Six).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Seven).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Eight).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Nine).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Ten).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Jack).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.Queen).Should().Be(4 * packQuantity);
        deck.Count(x=>x.Value == CardValue.King).Should().Be(4 * packQuantity);
    }

    private static void OutputCards(IEnumerable<Card> deck)
    {
        foreach (var card in deck)
        {
            TestContext.Out.WriteLine(card);
        }
    }
}