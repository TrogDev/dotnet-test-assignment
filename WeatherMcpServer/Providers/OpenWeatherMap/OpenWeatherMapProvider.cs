using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using WeatherMcpServer.Exceptions;
using WeatherMcpServer.Interfaces;
using WeatherMcpServer.Models;
using WeatherMcpServer.Providers.OpenWeatherMap.Models;

namespace WeatherMcpServer.Providers.OpenWeatherMap;

public class OpenWeatherMapProvider : IWeatherProvider, IDisposable
{
    private const string baseUrl = "https://api.openweathermap.org/data/2.5";
    private const string units = "metric";

    private readonly string token;
    private readonly HttpClient client;
    private readonly ILogger<OpenWeatherMapProvider> logger;

    public OpenWeatherMapProvider(ILogger<OpenWeatherMapProvider> logger)
    {
        this.logger = logger;
        token = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_TOKEN")!;
        client = new HttpClient();
    }

    public async Task<WeatherInfo> GetCurrentWeather(string city, string? countryCode = null)
    {
        HttpResponseMessage response = await client.GetAsync(
            $"{baseUrl}/weather?q={city},{countryCode}&units={units}&appid={token}"
        );
        ValidateWeatherResponse(response);
        WeatherResponse data = (await response.Content.ReadFromJsonAsync<WeatherResponse>())!;
        return CastWeatherInfo(data);
    }

    public async Task<List<WeatherInfo>> GetWeatherForecast(string city, string? countryCode = null)
    {
        HttpResponseMessage response = await client.GetAsync(
            $"{baseUrl}/forecast?q={city},{countryCode}&units={units}&appid={token}"
        );
        ValidateWeatherResponse(response);
        ForecastResponse data = (await response.Content.ReadFromJsonAsync<ForecastResponse>())!;
        return data.List.Select(CastWeatherInfo).ToList();
    }

    private void ValidateWeatherResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                logger.LogError(
                    "Token is invalid or missing. Please check the OPEN_WEATHER_MAP_TOKEN environment variable."
                );
                throw new InvalidTokenException("Invalid or missing token");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                logger.LogError("City not found. Please check the city name and country code.");
                throw new CityNotFoundException("City not found");
            }
            else
            {
                logger.LogError($"Unexpected error: {response.ReasonPhrase}");
                throw new ApiException($"Unexpected error: {response.ReasonPhrase}");
            }
        }
    }

    private WeatherInfo CastWeatherInfo(WeatherResponse data)
    {
        return new WeatherInfo()
        {
            DateTime = DateTimeOffset
                .FromUnixTimeSeconds(data.Timestamp)
                .ToOffset(TimeSpan.FromSeconds(data.Timezone))
                .DateTime,
            TemperatureCelsius = data.Main.Temperature,
            Conditions = [.. data.Weather.Select(e => e.MainCondition)]
        };
    }

    public void Dispose()
    {
        client.Dispose();
    }
}
