namespace WeatherMcpServer.Models;

public record WeatherInfo
{
    public required DateTime DateTime { get; set; }
    public required double TemperatureCelsius { get; set; }
    public required List<string> Conditions { get; set; }
}
