using System.ComponentModel;
using MCPDemo.Api.Models;
using MCPDemo.MCP.Clients;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class LocationTools(ICovidApiClient covidApiClient)
{
    [McpServerTool(Name = "GetCountries")]
    [Description("Fetches the unique list of countries from which data is gathered regarding Covid-19 cases")]
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        return await covidApiClient.GetCountries();
    }

    [McpServerTool(Name = "GetRegionsForCountry")]
    [Description("Fetches the unique list of regions for a country")]
    public async Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode)
    {
        return await covidApiClient.GetRegionsForCountry(countryCode);
    }
}