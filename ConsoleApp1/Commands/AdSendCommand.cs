using ConsoleApp1.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = ConsoleApp1.Entities.User;

namespace ConsoleApp1.Commands;

public class AdSendCommand(List<User> users): ICommand
{
    public async Task ExecuteAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var senderId = update.Message.From?.Id!;
        var text  = update.Message!.Text;
        foreach (var user in users.Where(u => u.Id != senderId))
        {
            await client.SendTextMessageAsync(user.Id, text, cancellationToken: cancellationToken);
        }
        var userPidar = users.First(u => u.Id == update.Message.From.Id);
        userPidar.State = UserState.Main;
    } 
    

    public bool CanBeExecuted(Update update)
    {
        if(update.Message is not { Type: MessageType.Text }) return false;
        var user = users.FirstOrDefault(u => u.Id == update.Message.From.Id);
        return user?.State == UserState.WaitingForSending;
    }
}