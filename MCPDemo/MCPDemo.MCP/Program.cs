
using MCPDemo.MCP.Interfaces;
using MCPDemo.MCP.Clients;
using MCPDemo.MCP.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.WebHost.UseUrls("http://0.0.0.0:8080");
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithTools<TotalCasesTools>()
    .WithTools<LocationTools>()
    .WithTools<RatesTool>();
 
var configuration = builder.Configuration;
var covidClientBaseUrl = configuration["CovidApiClientBaseUrl"];

builder.Services.AddHttpClient<ICovidDataClient, CovidApiDataClient>(options =>
{
    options.BaseAddress = new Uri(covidClientBaseUrl ?? throw new Exception("Boom"));
    //options.BaseAddress = new Uri("http://localhost:5290/");
});

var app = builder.Build();

app.MapGet("/healthz", () => "Service is running");
app.MapMcp();

Console.WriteLine("MCP Server starting on http://0.0.0.0:8080");
await app.RunAsync();