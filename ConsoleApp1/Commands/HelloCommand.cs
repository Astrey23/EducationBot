using System.Net;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;
using User = ConsoleApp1.Entities.User;

namespace ConsoleApp1.Commands;

public class HelloCommand(List<User> users) : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var username = update.Message.From?.FirstName;
        var senderId = update.Message.From?.Id!;
        var me = await client.GetMeAsync(cancellationToken: cancellationToken);
        string message;
        if (users.All(u => u.Id != senderId))
        {
            message = $"Привет {username}, я {me.FirstName}, скинь мне геолокацию, а я тебе прогноз погоды на завтра.";
            users.Add(new User{Id = senderId.Value});
        }
        else
        {
            message = $"Dolbaeb {senderId}";
        }

        await client.SendTextMessageAsync(senderId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text };
    }
}