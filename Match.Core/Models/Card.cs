using Match.Core.Enums;

namespace Match.Core.Models;

public class Card
{
    public Card(CardValue value, Suit suit)
    {
        Value = value;
        Suit = suit;
    }

    public CardValue Value { get; private set; }
    public Suit Suit { get; private set; }

    public override string ToString() => $"{Value} of {Suit.Name} ({Suit.Symbol})";
}