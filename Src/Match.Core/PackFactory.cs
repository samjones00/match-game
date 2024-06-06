using Match.Core.Enums;
using Match.Core.Models;

namespace Match.Core
{
    public static class PackFactory
    {
        public static IEnumerable<Card> CreateDeck(int packQuantity) => Enumerable.Range(0, packQuantity).Select(x => CreatePack()).SelectMany(x => x);

        private static List<Card> CreatePack()
        {
            var suits = Enum.GetValues(typeof(Suit));
            var values = Enum.GetValues(typeof(CardValue));

            var pack = new List<Card>();
            foreach (Suit suit in suits)
            {
                foreach (CardValue value in values)
                {
                    pack.Add(CreateCard(suit, value));
                }
            }

            return pack;
        }

        private static Card CreateCard(Suit suit, CardValue value) => new(value, suit, GetSuitSymbol(suit));

        private static string GetSuitSymbol(Suit suit) => suit switch
        {
            Suit.Clubs => "♣",
            Suit.Diamonds => "♦",
            Suit.Hearts => "♥",
            Suit.Spades => "♠",
            _ => throw new NotSupportedException($"Suit not supported: {suit}"),
        };
    }
}