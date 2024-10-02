using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class HelloCommand: ICommand
{
    private readonly List<long> _users = [];
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var username = update.Message.From?.FirstName;
        var chatId = update.Message.Chat.Id;
        var me = await client.GetMeAsync(cancellationToken: cancellationToken);
        string message;
        if (!_users.Contains(chatId))
        {
            message = $"Привет {username}, я {me.FirstName}, скинь мне геолокацию, а я тебе прогноз погоды на завтра.";
            _users.Add(chatId);
        }
        else
        {
            message = $"Dolbaeb";
        }
        await client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text };
    }
}

