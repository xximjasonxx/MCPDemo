using System.ComponentModel;
using MCPDemo.MCP.Interfaces;
using MCPDemo.Common.ResponsModels;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class LocationTools(ICovidDataClient covidDataClient)
{
    [McpServerTool(Name = "GetCountries")]
    [Description("Fetches the unique list of countries from which data is gathered regarding Covid-19 cases")]
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        return await covidDataClient.GetCountries();
    }

    [McpServerTool(Name = "GetRegionsForCountry")]
    [Description("Fetches the unique list of regions for a country")]
    public async Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode)
    {
        return await covidDataClient.GetRegionsForCountry(countryCode);
    }
}