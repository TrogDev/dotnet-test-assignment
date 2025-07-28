namespace WeatherMcpServer.Exceptions;

public class InvalidTokenException : ApiException
{
    public InvalidTokenException(string message)
        : base(message) { }

    public InvalidTokenException(string message, Exception innerException)
        : base(message, innerException) { }
}
