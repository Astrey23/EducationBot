using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands;

public interface ICommand
{
    Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    bool CanBeExecuted(Update update);
}