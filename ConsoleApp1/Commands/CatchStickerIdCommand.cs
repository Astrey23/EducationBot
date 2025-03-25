using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class CatchStickerIdCommand : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        var stickerId = update.Message.Sticker.FileId;
        string message = $"Sticker ID: {stickerId}";
        await client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Sticker };
    }
}