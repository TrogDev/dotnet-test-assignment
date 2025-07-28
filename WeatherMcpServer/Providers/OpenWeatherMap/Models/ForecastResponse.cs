using System.Text.Json.Serialization;

namespace WeatherMcpServer.Providers.OpenWeatherMap.Models;

public record ForecastResponse
{
    [JsonPropertyName("list")]
    public List<WeatherResponse> List { get; set; } = [];
}
