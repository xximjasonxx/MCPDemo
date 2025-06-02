
using MCPDemo.MCP.Interfaces;
using MCPDemo.MCP.Clients;
using MCPDemo.MCP.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<TotalCasesTools>()
    .WithTools<LocationTools>();
    
builder.Services.AddHttpClient<ICovidDataClient, CovidApiDataClient>(options =>
{
    options.BaseAddress = new Uri("https://aca-mcp-demo-api-mx01.yellowgrass-7d797e98.eastus2.azurecontainerapps.io");
    //options.BaseAddress = new Uri("http://localhost:5290/");
});

await builder.Build().RunAsync();