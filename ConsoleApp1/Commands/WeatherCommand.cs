using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands;

public class WeatherCommand : ICommand
{
    public async Task Execute(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.CallbackQuery!.From.Id;
        var data = update.CallbackQuery.Data!.Split('_');
        var latitude = double.Parse(data[1]);
        var longitude = double.Parse(data[2]);
        var day = int.Parse(data[3]);
        using var clientHttp = new HttpClient();
        var url = $"https://www.7timer.info/bin/civillight.php?lon={longitude}4&lat={latitude}&output=json";
        var response = await clientHttp.GetStringAsync(url, cancellationToken);
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
        var weather = weatherData.Dataseries[day];
        var text = $"Погода на {weather.Date} - {weather.Weather} \nМинимальная температура: {weather.Temperature.Min} градусов \nМаксимальная температура: {weather.Temperature.Max} градусов \nСкорость ветра: {weather.WindSpeed} м/c";
        await client.SendTextMessageAsync(chatId, text, cancellationToken: cancellationToken);
    }

    public bool CanBeExecuted(Update update)
    {
        return update.CallbackQuery?.Data != null && update.CallbackQuery.Data.StartsWith("weather");
    }
}