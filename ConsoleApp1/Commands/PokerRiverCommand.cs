using ConsoleApp1.Abstractions;
using ConsoleApp1.Presentation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class PokerRiverCommand(IUserRepository userRepository, IPokerGameRepository gameRepository) : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        var userId = update.Message!.From!.Id;

        var user = await userRepository.GetAsync(userId, cancellationToken);

        if (user?.CurrentGameId == null) return;

        var game = await gameRepository.GetAsync(user.CurrentGameId.Value, cancellationToken);

        if (game == null) return;
        
        game.River();
        game.CheckCombination(userId, game);

        const string turnMessage = "Ривер хуивер:";
        await client.SendTextMessageAsync(chatId, turnMessage, cancellationToken: cancellationToken);

        foreach (var card in game.CardsInTable)
        {
            await client.SendStickerAsync(chatId, new InputFileId(PokerCards.CardsStickers[card]), cancellationToken: cancellationToken);
        }
    }
    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text, Text: "/river" };
    }
}