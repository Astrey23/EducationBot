using ConsoleApp1.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

ICommand[] commands = {new EgorCommand(), new HelloCommand(), new WeatherCommand()};

using var cts = new CancellationTokenSource();
var client = new TelegramBotClient("7594165971:AAFQqR4KMFwaWMx42h01CVe-iHwX0msYszE");
client.StartReceiving(OnUpdate,OnError,null,cts.Token);
Console.ReadLine();


// method that handle messages received by the bot:
async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    foreach (var command in commands)
    {
        if (!command.CanBeExecuted(update)) continue;
        await command.Execute(client, update, cancellationToken);
        break;
    }
}

Task OnError(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
{
    return Task.CompletedTask;
}