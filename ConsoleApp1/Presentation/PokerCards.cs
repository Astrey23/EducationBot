using ConsoleApp1.Entities.Games;
using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Presentation;

public static class PokerCards
{
    public static readonly Dictionary<Card, string> CardsStickers = new()
    {
        { new Card(Suit.Hearts, Rank.Two), "111" },
        { new Card(Suit.Hearts, Rank.Three), "3" },
    };
}