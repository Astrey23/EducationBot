using ConsoleApp1.Abstractions;
using ConsoleApp1.Entities.Games;

namespace ConsoleApp1.Infrastructure;

public class InMemoryPokerGameRepository : IPokerGameRepository
{
    private readonly List<PokerGame> _games = [];
    public Task AddAsync(PokerGame game, CancellationToken cancellationToken)
    {
        _games.Add(game);
        return Task.CompletedTask;
    }

    public Task<PokerGame?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_games.FirstOrDefault(u => u.Id == id));
    }
}