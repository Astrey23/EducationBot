using ConsoleApp1.Entities;
using ConsoleApp1.Entities.Users;

namespace ConsoleApp1.Abstractions;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetAsync(long id, CancellationToken cancellationToken = default);
}