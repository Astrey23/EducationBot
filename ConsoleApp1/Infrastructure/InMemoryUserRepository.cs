using ConsoleApp1.Abstractions;
using ConsoleApp1.Entities;
using ConsoleApp1.Entities.Users;

namespace ConsoleApp1.Infrastructure;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = [];
    public Task AddAsync(User user, CancellationToken cancellationToken)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetAsync(long id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }
}