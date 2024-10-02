using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class EgorCommand: ICommand
{
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var message = "Хорош";
        await client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message != null && update.Message.Type == MessageType.Text && update.Message.Text == "Я Егор";
    }
}