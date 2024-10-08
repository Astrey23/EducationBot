using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands;

public interface ICommand
{
    Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    bool CanBeExecuted(Update update);
}