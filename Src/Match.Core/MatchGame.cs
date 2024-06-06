using Match.Core.Enums;
using Match.Core.Interfaces;
using Match.Core.Models;

namespace Match.Core;

public class MatchGame : IMatchGame
{
    public int Play(int packQuantity, int matchConditionIndex)
    {
        var cards = PackFactory.CreateDeck(packQuantity);
        var shuffled = Shuffle(cards.ToArray());
        var deck = ConvertToQueue(shuffled);

        var pile = new List<Card>();
        var players = new Dictionary<int, List<Card>>
        {
            { 1, [] },
            { 2, [] }
        };

        var matchCondition = (MatchCondition)matchConditionIndex;
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"Match condition selected: {matchCondition.ToSentenceCase()}");

        do
        {
            var player1Card = TakeCard(deck);
            Console.WriteLine($"Player 1 takes {player1Card}");

            var player2Card = TakeCard(deck);
            Console.WriteLine($"Player 2 takes {player2Card}");

            pile.Add(player1Card);
            pile.Add(player2Card);

            if (IsMatch(player1Card, player2Card, matchCondition))
            {
                var matchWinner = GetMatchWinner(players);
                players[matchWinner].AddRange(pile);
                pile.Clear();

                Console.WriteLine($"Match! Player {matchWinner} wins! Player 1: {player1Card}, Player 2: {player2Card}.");
            }
        }
        while (deck.Count > 0);

        if (IsDraw(players))
        {
            Console.WriteLine($"It's a draw, Player 1: {players[1].Count}, Player 2: {players[2].Count}");
            return 0;
        }

        var gameWinner = GetGameWinner(players);
        var gameLooser = players.First(x => x.Key != gameWinner).Key;
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"Player {gameWinner} wins the game with {players[gameWinner].Count} cards, Player {gameLooser} has {players[gameLooser].Count} cards");

        return gameWinner;
    }

    private T[] Shuffle<T>(T[] source)
    {
        Random.Shared.Shuffle(source);
        return source;
    }

    private int GetMatchWinner(Dictionary<int, List<Card>> players)
    {
        var playerNumbers = players.Select(x => x.Key).ToArray();
        Shuffle(playerNumbers);

        return playerNumbers.First();
    }

    private static int GetGameWinner(Dictionary<int, List<Card>> players) => players.OrderByDescending(x => x.Value.Count).First().Key;

    private static bool IsDraw(Dictionary<int, List<Card>> players)
    {
        return players[1].Count() == players[2].Count();
    }

    private static Queue<Card> ConvertToQueue(IEnumerable<Card> cards)
    {
        var deck = new Queue<Card>();
        foreach (var card in cards)
        {
            deck.Enqueue(card);
        }

        return deck;
    }

    private static Card TakeCard(Queue<Card> deck)
    {
        var card = deck.Dequeue();
        return card;
    }

    private static bool IsMatch(Card card1, Card card2, MatchCondition matchCondition) => matchCondition switch
    {
        MatchCondition.SuitsOfTwoCardsMustMatch => card1.Suit.Equals(card2.Suit),
        MatchCondition.ValuesOfTwoCardsMustMatch => card1.Value.Equals(card2.Value),
        MatchCondition.BothSuitAndValueMustMatch => card1.Suit.Equals(card2.Suit) && card1.Value.Equals(card2.Value),
        _ => throw new NotSupportedException($"Match condition not supported: {matchCondition}"),
    };
}