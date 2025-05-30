
using MCPDemo.MCP.Interfaces;
using MCPDemo.MCP.Clients;
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
    .WithToolsFromAssembly();
    
builder.Services.AddHttpClient<ICovidCasesDataClient, CovidCasesDataCasesDataClient>(options =>
{
    options.BaseAddress = new Uri("https://aca-mcp-demo-api-mx01.yellowgrass-7d797e98.eastus2.azurecontainerapps.io");
});

builder.Services.AddHttpClient<ICovidLocationDataClient, CovidApiLocationDataClient>(options =>
{
    options.BaseAddress = new Uri("https://aca-mcp-demo-api-mx01.yellowgrass-7d797e98.eastus2.azurecontainerapps.io");
});


await builder.Build().RunAsync();