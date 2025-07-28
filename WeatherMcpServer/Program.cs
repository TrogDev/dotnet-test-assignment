using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherMcpServer.Interfaces;
using WeatherMcpServer.Providers.OpenWeatherMap;
using WeatherMcpServer.Tools;

var builder = Host.CreateApplicationBuilder(args);

// Configure all logs to go to stderr (stdout is used for the MCP protocol messages).
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Trace);

// Add the MCP services: the transport to use (stdio) and the tools to register.
builder.Services.AddMcpServer().WithStdioServerTransport().WithTools<WeatherTools>();

builder.Services.AddScoped<IWeatherProvider, OpenWeatherMapProvider>();

await builder.Build().RunAsync();
