# Setup
- Open the current folder in VS Code.
- Set up your OpenWeatherMap token by adding it to the OPEN_WEATHER_MAP_TOKEN environment variable in .vscode/mcp.json. (Or just use the token that's already set in the variable) 
- Start the server via the Extensions tab or by clicking the Start button in mcp.json.

# Usage
- Open GitHub Copilot in VS Code as an Agent and ask for the weather in a specific city.
- Click Continue to receive a response from the MCP server.

# Code Highlights
- Weather data is provided through the IWeatherProvider interface. Implementations are located in the Providers folder (currently only OpenWeatherMap is supported).
- MCP tools are located in the Tools folder.
- API exceptions in OpenWeatherMapProvider are logged using a logger.
