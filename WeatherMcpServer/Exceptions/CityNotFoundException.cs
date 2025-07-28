namespace WeatherMcpServer.Exceptions;

public class CityNotFoundException : ApiException
{
    public CityNotFoundException(string message)
        : base(message) { }

    public CityNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}
