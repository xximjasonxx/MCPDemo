
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
    .WithTools<LocationTools>()
    .WithTools<RatesTool>();
 
var configuration = builder.Configuration;
var covidClientBaseUrl = configuration["CovidApiClientBaseUrl"];
Console.WriteLine($"Base URL: {covidClientBaseUrl}");

builder.Services.AddHttpClient<ICovidDataClient, CovidApiDataClient>(options =>
{
    options.BaseAddress = new Uri(covidClientBaseUrl ?? throw new Exception("Boom"));
    //options.BaseAddress = new Uri("http://localhost:5290/");
});

await builder.Build().RunAsync();