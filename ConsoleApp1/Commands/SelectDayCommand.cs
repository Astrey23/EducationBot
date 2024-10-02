using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp1.Commands;

public class SelectDayCommand : ICommand
{
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var location = update.Message!.Location!;
        const string format = "weather_{0}_{1}_{2}";
        var firstButtonQuery = string.Format(format, location.Latitude, location.Longitude, 0);
        var secondButtonQuery = string.Format(format, location.Latitude, location.Longitude, 1);
        var thirdButtonQuery = string.Format(format, location.Latitude, location.Longitude, 2);
        
        InlineKeyboardButton[] buttons =
        [
            InlineKeyboardButton.WithCallbackData("На сегодня", firstButtonQuery),
            InlineKeyboardButton.WithCallbackData("На завтра", secondButtonQuery),
            InlineKeyboardButton.WithCallbackData("На послезавтра", thirdButtonQuery)
        ];
        var replyMarkup = new InlineKeyboardMarkup(buttons);


        var chatId = update.Message!.Chat.Id;
        await client.SendTextMessageAsync(chatId, "Выберите день:", replyMarkup: replyMarkup,
            cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Location: not null };
    }
}