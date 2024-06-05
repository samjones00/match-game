using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Match.Core.Enums;
using Match.Core.Models;

namespace Match.Core
{
    public class PackFactory
    {
        public IEnumerable<Card> CreatePack()
        {
            var suits = Enum.GetValues(typeof(SuitType));
            var values = Enum.GetValues(typeof(CardValue));

            var pack = new List<Card>();
            foreach (SuitType suit in suits)
            {
                foreach (CardValue value in values)
                {
                    var card = CreateCard(suit, value);
                    pack.Add(card);
                }
            }

            return pack;
        }

        private Card CreateCard(SuitType suitType, CardValue value)
        {
            return new Card(value, CreateSuit(suitType));
        }

        private Suit CreateSuit(SuitType suit)
        {
            return suit switch
            {
                SuitType.Clubs => new(suit.ToString(), "♣"),
                SuitType.Diamonds => new(suit.ToString(), "♦"),
                SuitType.Hearts => new(suit.ToString(), "♥"),
                SuitType.Spades => new(suit.ToString(), "♠"),
                _ => throw new ArgumentOutOfRangeException(nameof(suit), $"Not expected direction value: {suit}"),
            };
        }
    }
}