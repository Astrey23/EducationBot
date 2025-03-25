using ConsoleApp1;
using ConsoleApp1.Commands;
using ConsoleApp1.Infrastructure;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;
using User = ConsoleApp1.Entities.Users.User;

const string FilePath = "appsettings.json";
string json = File.ReadAllText(FilePath);
AppConfiguration? adminInfo = JsonConvert.DeserializeObject<AppConfiguration>(json);

var userRepository = new InMemoryUserRepository();
var gameRepository = new InMemoryPokerGameRepository();

ICommand[] commands =
[
    new PokerStartCommand(userRepository, gameRepository),
    new SelectDayCommand(),
    new HelloCommand(userRepository), 
    new WeatherCommand(), 
    new CatchStickerIdCommand()
];

using var cts = new CancellationTokenSource();
var client = new TelegramBotClient(adminInfo.Token);
client.StartReceiving(OnUpdate, OnError, null, cts.Token);
Console.ReadLine();
return;


// method that handle messages received by the bot:
async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    foreach (var command in commands)
    {
        if (!command.CanBeExecuted(update)) continue;
        await command.ExecuteAsync(client, update, cancellationToken);
        break;
    }
}

Task OnError(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
{
    return Task.CompletedTask;
}