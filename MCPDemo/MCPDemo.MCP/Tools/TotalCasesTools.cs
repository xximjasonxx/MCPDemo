using System.ComponentModel;
using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Clients;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class TotalCasesTools(ICovidApiClient covidApiClient)
{
    [McpServerTool(Name = "GetFinalCasesForCountry")]
    [Description("Given a country code (2 characters) returns the final numbers for confirmed, deceased, recovered and tests for a country")]
    public async Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode)
    {
        return await covidApiClient.GetFinalCasesForCountry(countryCode);
    }

    [McpServerTool(Name = "GetTotalCasesForAllCountries")]
    [Description("Returns the aggregated data concerning cases for all countries reporting")]
    public async Task<List<CountryCaseTotalResponseModel>> GetTotalCasesForAllCountries()
    {
        return await covidApiClient.GetFinalCasesForAllCountries();
    }

    [McpServerTool(Name = "GetTotalCasesForCountryRegions")]
    [Description("Given a country code (2 characters) returns the final numbers for each top level region in that country reporting Covid cases")]
    public async Task<List<CountryRegionCasesTotalResponseModel>> GetTotalCasesForCountryRegions(string countryCode)
    {
        return await covidApiClient.GetFinalCasesForCountryRegions(countryCode);
    }
}