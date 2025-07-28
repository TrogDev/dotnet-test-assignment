using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;
using WeatherMcpServer.Exceptions;
using WeatherMcpServer.Interfaces;

namespace WeatherMcpServer.Tools;

public class WeatherTools
{
    private IWeatherProvider weatherProvider;

    public WeatherTools(IWeatherProvider weatherProvider)
    {
        this.weatherProvider = weatherProvider;
    }

    [McpServerTool]
    [Description("Gets current weather info for the specified city")]
    public async Task<string> GetCurrentWeather(
        [Description("Name of the city to return weather for")] string city,
        [Description("Optional: Country code (e.g., 'US', 'GB')")] string? countryCode = null
    )
    {
        try
        {
            return JsonSerializer.Serialize(
                await weatherProvider.GetCurrentWeather(city, countryCode)
            );
        }
        catch (CityNotFoundException)
        {
            return "Error: City not found";
        }
    }

    [McpServerTool]
    [Description("Gets weather forecast for the specified city")]
    public async Task<string> GetWeatherForecast(
        [Description("Name of the city to return weather for")] string city,
        [Description("Optional: Country code (e.g., 'US', 'GB')")] string? countryCode = null
    )
    {
        try
        {
            return JsonSerializer.Serialize(
                await weatherProvider.GetWeatherForecast(city, countryCode)
            );
        }
        catch (CityNotFoundException)
        {
            return "Error: City not found";
        }
    }
}
