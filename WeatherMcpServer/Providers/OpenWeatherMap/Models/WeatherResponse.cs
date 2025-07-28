using System.Text.Json.Serialization;

namespace WeatherMcpServer.Providers.OpenWeatherMap.Models;

public record WeatherResponse(
    [property: JsonPropertyName("coord")] Coord Coord,
    [property: JsonPropertyName("weather")] Weather[] Weather,
    [property: JsonPropertyName("base")] string Base,
    [property: JsonPropertyName("main")] Main Main,
    [property: JsonPropertyName("visibility")] int Visibility,
    [property: JsonPropertyName("wind")] Wind Wind,
    [property: JsonPropertyName("clouds")] Clouds Clouds,
    [property: JsonPropertyName("dt")] long Timestamp,
    [property: JsonPropertyName("sys")] Sys Sys,
    [property: JsonPropertyName("timezone")] int Timezone,
    [property: JsonPropertyName("id")] int CityId,
    [property: JsonPropertyName("name")] string CityName,
    [property: JsonPropertyName("cod")] int StatusCode
);

public record Coord(
    [property: JsonPropertyName("lon")] double Longitude,
    [property: JsonPropertyName("lat")] double Latitude
);

public record Weather(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("main")] string MainCondition,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("icon")] string Icon
);

public record Main(
    [property: JsonPropertyName("temp")] double Temperature,
    [property: JsonPropertyName("feels_like")] double FeelsLike,
    [property: JsonPropertyName("temp_min")] double TemperatureMin,
    [property: JsonPropertyName("temp_max")] double TemperatureMax,
    [property: JsonPropertyName("pressure")] int Pressure,
    [property: JsonPropertyName("humidity")] int Humidity,
    [property: JsonPropertyName("sea_level")] int SeaLevel,
    [property: JsonPropertyName("grnd_level")] int GroundLevel
);

public record Wind(
    [property: JsonPropertyName("speed")] double Speed,
    [property: JsonPropertyName("deg")] int Degree,
    [property: JsonPropertyName("gust")] double Gust
);

public record Clouds([property: JsonPropertyName("all")] int Cloudiness);

public record Sys(
    [property: JsonPropertyName("type")] int Type,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("sunrise")] long Sunrise,
    [property: JsonPropertyName("sunset")] long Sunset
);
