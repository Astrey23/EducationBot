using ConsoleApp1.Entities.Games;

namespace ConsoleApp1.Abstractions;

public interface IPokerGameRepository
{
    Task AddAsync(PokerGame pokerGame, CancellationToken cancellationToken);
    Task<PokerGame?> GetAsync(Guid id, CancellationToken cancellationToken);
}