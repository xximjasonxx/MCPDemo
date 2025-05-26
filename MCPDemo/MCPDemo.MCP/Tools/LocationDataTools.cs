using System.ComponentModel;
using MCPDemo.Api.Models;
using MCPDemo.MCP.Clients;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class LocationDataTools(ICovidApiClient covidApiClient)
{
    [McpServerTool(Name = "GetCountries", Title = "GetCountriesTool")]
    [Description("Fetches the unique list of countries from which data is gathered regarding Covid-19 cases")]
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        return await covidApiClient.GetCountries();
    }
}