using System.Net;
using ConsoleApp1.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = ConsoleApp1.Entities.User;
using Newtonsoft.Json;
using File = System.IO.File;

namespace ConsoleApp1.Commands;

public class AdCommand(List<User> users) : ICommand
{
    private const string FilePath = "C:\\Users\\Astrey\\RiderProjects\\ConsoleApp1\\ConsoleApp1\\adminId.json";

    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var senderId = update.Message.From?.Id!;
        const string message = "Жду сообщение для рассылки";
        await client.SendTextMessageAsync(senderId, message, cancellationToken: cancellationToken);
        var user = users.First(u => u.Id == update.Message.From.Id);
        user.State = UserState.WaitingForSending; 

    } 
    

    public bool CanBeExecuted(Update update)
    {
        string json = File.ReadAllText(FilePath);
        AdminInfo? adminInfo = JsonConvert.DeserializeObject<AdminInfo>(json);
        var senderId = update.Message?.From?.Id!;
        if(update.Message is not { Type: MessageType.Text, Text: "/ad" }) return false;
        if(adminInfo?.AdminId != senderId) return false;
        var user = users.FirstOrDefault(u => u.Id == update.Message.From.Id);
        return user?.State == UserState.Main;
    }
}