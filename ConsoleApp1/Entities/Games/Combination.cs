using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Entities.Games;

public struct Combination : IComparable<Combination>
{
    public required PokerHand Hand { get; init; }
    
    public required Rank Rank { get; init; }
    
    public Rank? SecondaryRank { get; init; }

    public int CompareTo(Combination other)
    {
        var handComparison = Hand.CompareTo(other.Hand);
        if (handComparison != 0) return handComparison;
        
        var rankComparison = Rank.CompareTo(other.Rank);
        if (rankComparison != 0) return rankComparison;
        
        return Nullable.Compare(SecondaryRank, other.SecondaryRank);
    }
}