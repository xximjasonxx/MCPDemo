using System.ComponentModel;
using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Interfaces;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class TotalCasesTools(ICovidCasesDataClient covidCasesDataClient)
{
    [McpServerTool(Name = "GetFinalCasesForCountry")]
    [Description("Given a country code (2 characters) returns the final numbers for confirmed, deceased, recovered and tests for a country")]
    public async Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode)
    {
        return await covidCasesDataClient.GetFinalCasesForCountry(countryCode);
    }

    [McpServerTool(Name = "GetTotalCasesForAllCountries")]
    [Description("Returns the aggregated data concerning cases for all countries reporting")]
    public async Task<List<CountryCaseTotalResponseModel>> GetTotalCasesForAllCountries()
    {
        return await covidCasesDataClient.GetFinalCasesForAllCountries();
    }

    [McpServerTool(Name = "GetTotalCasesForCountryRegions")]
    [Description("Given a country code (2 characters) returns the final numbers for each top level region in that country reporting Covid cases")]
    public async Task<List<CountryRegionCasesTotalResponseModel>> GetTotalCasesForCountryRegions(string countryCode)
    {
        return await covidCasesDataClient.GetFinalCasesForCountryRegions(countryCode);
    }

    [McpServerTool(Name = "GetTotalCasesForCountryRegionLocales")]
    [Description("Given a region code and country code find related case data for locales within that specific regions where Covid cases were reported")]
    public async Task<List<CountryRegionLocaleCasesTotalResponseModel>> GetTotalCasesForCountryRegionLocales(string countryCode, string regionCode)
    {
        return await covidCasesDataClient.GetFinalCasesForCountryRegionLocales(countryCode, regionCode);
    }
}