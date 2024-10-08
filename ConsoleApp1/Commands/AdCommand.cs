using ConsoleApp1.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = ConsoleApp1.Entities.User;

namespace ConsoleApp1.Commands;

public class AdCommand : ICommand
{
    private readonly List<User> _users;

    public AdCommand(List<User> users)
    {
        _users = users;
    }

    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var senderId = update.Message.From?.Id!;
        const string message = "Жду сообщение для рассылки";
        await client.SendTextMessageAsync(senderId, message, cancellationToken: cancellationToken);
        var user = _users.First(u => u.Id == update.Message.From.Id);
        user.State = UserState.WaitingForSending;

    } 
    

    public bool CanBeExecuted(Update update)
    {
        if(update.Message is not { Type: MessageType.Text, Text: "/ad" }) return false;
        var user = _users.FirstOrDefault(u => u.Id == update.Message.From.Id);
        return user?.State == UserState.Main;
    }
}