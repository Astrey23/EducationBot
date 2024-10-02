using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1.Commands;

public class WeatherCommand: ICommand
{
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var latitude = update.Message.Location.Latitude;
        var longitude = update.Message.Location.Longitude;
        var clientHttp = new HttpClient();
        string url = $"https://www.7timer.info/bin/civillight.php?lon={longitude}4&lat={latitude}&output=json";
        var response = await clientHttp.GetStringAsync(url);
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
        var day = weatherData.Dataseries[1].Weather;
        var text = $"Погода на завтра - {weatherData.Dataseries[1].Weather} \nМинимальная температура: {weatherData.Dataseries[1].Temp2m.Min} градусов \nМаксимальная температура: {weatherData.Dataseries[1].Temp2m.Max} градусов \nСкорость ветра: {weatherData.Dataseries[1].Wind10m_Max} м/c";
        await client.SendTextMessageAsync(chatId, text, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.Message is { Location: not null };
    }
}