using WeatherMcpServer.Models;

namespace WeatherMcpServer.Interfaces;

public interface IWeatherProvider
{
    Task<WeatherInfo> GetCurrentWeather(string city, string? countryCode = null);
    Task<List<WeatherInfo>> GetWeatherForecast(string city, string? countryCode = null);
}
