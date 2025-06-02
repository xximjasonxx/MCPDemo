// See https://aka.ms/new-console-template for more information

using MCPDemo.MCP.Clients;

var httpClient = new HttpClient()
{
    BaseAddress = new Uri("https://aca-mcp-demo-api-mx01.yellowgrass-7d797e98.eastus2.azurecontainerapps.io")
};

var client = new CovidApiDataClient(httpClient);
var result = await client.GetFinalCasesForCountry("AF");