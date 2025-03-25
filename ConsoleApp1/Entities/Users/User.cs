using ConsoleApp1.Entities.Users.Enums;

namespace ConsoleApp1.Entities.Users;

public class User
{
    public required long Id { get ; init; }
    public UserState State { get ; set ; }
    
    public Guid? CurrentGameId { get ; set ; }
}