using ConsoleApp1.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = ConsoleApp1.Entities.Users.User;

namespace ConsoleApp1.Commands;

public class HelloCommand(IUserRepository repository) : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var username = update.Message.From?.FirstName;
        var senderId = update.Message.From?.Id!;
        var me = await client.GetMeAsync(cancellationToken: cancellationToken);
        string message;
        var user = await repository.GetAsync(senderId.Value, cancellationToken);
        if (user == null)
        {
            message = $"Привет {username}, я {me.FirstName}, скинь мне геолокацию, а я тебе прогноз погоды на завтра.";
            await repository.AddAsync(new User{Id = senderId.Value}, cancellationToken);
        }
        else
        {
            message = "Dolbaeb";
        }

        await client.SendTextMessageAsync(senderId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text };
    }
}