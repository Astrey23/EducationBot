using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Entities.Games;

public readonly struct Card(Suit suit, Rank rank) : IEquatable<Card>
{
    public Suit Suit { get; } = suit;
    public Rank Rank { get; } = rank;

    public override int GetHashCode()
    {
        return HashCode.Combine(Suit, Rank);
    }

    public bool Equals(Card other)
    {
        return Suit == other.Suit && Rank == other.Rank;
    }

    public override bool Equals(object? obj)
    {
        return obj is Card other && Equals(other);
    }

    public static bool operator ==(Card left, Card right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Card left, Card right)
    {
        return !(left == right);
    }
}