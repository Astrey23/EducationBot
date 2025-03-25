using ConsoleApp1.Abstractions;
using ConsoleApp1.Entities.Games;
using ConsoleApp1.Presentation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class PokerStartCommand(IUserRepository userRepository, IPokerGameRepository gameRepository) : ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        var userId = update.Message!.From!.Id;
        var name = update.Message!.From!.FirstName;

        var user = await userRepository.GetAsync(userId, cancellationToken);
        
        if(user == null) return;
        
        var game = new PokerGame();
        game.AddPlayer(userId, name);
        game.Start();

        user.CurrentGameId = game.Id;

        await gameRepository.AddAsync(game, cancellationToken);
        
        const string message = "Твои карты брат:";
        await client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);

        var cards = game.GetCards(userId);
        
        foreach (var card in cards)
        {
            await client.SendStickerAsync(chatId, new InputFileId(PokerCards.CardsStickers[card]), cancellationToken: cancellationToken);
        }
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Type: MessageType.Text, Text: "/poker" };
    }
}