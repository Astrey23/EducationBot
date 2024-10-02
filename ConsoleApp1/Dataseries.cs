using Newtonsoft.Json;

namespace ConsoleApp1;

public class Dataseries
{
    public required int Date { get; init; }
    public required string Weather { get; init; }
    
    [JsonProperty("Temp2m")]
    public required Temperature Temperature { get; init; }
    
    [JsonProperty("Wind10m_Max")]
    public required int WindSpeed { get; init; }
}