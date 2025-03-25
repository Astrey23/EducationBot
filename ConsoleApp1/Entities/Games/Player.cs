namespace ConsoleApp1.Entities.Games;

public struct Player
{
    public Card[]? Cards { get; set; }
    public required long UserId { get; init; }
    public required string Name { get; init; }

    public override int GetHashCode()
    {
        return UserId.GetHashCode();
    }
}