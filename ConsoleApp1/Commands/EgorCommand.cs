using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class EgorCommand : ICommand
{
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        const string message = "Хорош";
        await client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text, Text: "Я Егор" };
    }
}