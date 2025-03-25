using ConsoleApp1.Abstractions;
using ConsoleApp1.Entities.Games;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands;

public class PokerTurnCommand(IUserRepository userRepository, IPokerGameRepository gameRepository) : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        var userId = update.Message!.From!.Id;

        var user = await userRepository.GetAsync(userId, cancellationToken);
        
        if(user?.CurrentGameId == null) return;
        
        var game = await gameRepository.GetAsync(user.CurrentGameId.Value, cancellationToken);
        
        const string turnMessage = "Вот и Терн подъехал:";
        await client.SendTextMessageAsync(chatId, turnMessage, cancellationToken: cancellationToken);
        if (PokerGame.TurnCard != null)
        {
            var sticker = new InputFileId(PokerGame.TurnCard);
            await client.SendStickerAsync(chatId, sticker, cancellationToken: cancellationToken);
        }
    }
    public PokerGame PokerGame { get; set; }
    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text, Text: "/turn" };
    }
}