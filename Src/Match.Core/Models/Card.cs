using Match.Core.Enums;

namespace Match.Core.Models;

public record Card(CardValue Value, Suit SuitName, string Symbol)
{
    public CardValue Value { get; private set; } = Value;
    public string Suit { get; private set; } = SuitName.ToString();
    public string Symbol { get; private set; } = Symbol;

    public override string ToString() => $"{Value} of {Suit} {Symbol}";
}