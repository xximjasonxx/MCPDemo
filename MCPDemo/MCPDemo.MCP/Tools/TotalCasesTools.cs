using System.ComponentModel;
using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Interfaces;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class TotalCasesTools(ICovidDataClient covidDataClient)
{
    [McpServerTool(Name = "GetFinalCasesForCountry")]
    [Description("Returns the final case number information including confirmed, deceased, recovered and the final tests conducted for a given country. The country is identified by a code represented as a 2 character string")]
    public async Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode)
    {
        return await covidDataClient.GetFinalCasesForCountry(countryCode);
    }

    [McpServerTool(Name = "GetTotalCasesForAllCountries")]
    [Description("Returns the final case number information including confirmed, deceased, recovered and the final tests conducted for all available countries")]
    public async Task<List<CountryCaseTotalResponseModel>> GetTotalCasesForAllCountries()
    {
        return await covidDataClient.GetFinalCasesForAllCountries();
    }

    [McpServerTool(Name = "GetTotalCasesForCountryRegions")]
    [Description("Returns the final case number information including confirmed, deceased, recovered and the final tests conducted for all regions within a country. The country is identified by a code reoresented as a 2 character string")]
    public async Task<List<CountryRegionCasesTotalResponseModel>> GetTotalCasesForCountryRegions(string countryCode)
    {
        return await covidDataClient.GetFinalCasesForCountryRegions(countryCode);
    }

    [McpServerTool(Name = "GetTotalCasesForCountryRegionLocales")]
    [Description("Returns the final numbers including confirmed, deceased, recovered cases and the final tests conducted for Covid within a specific country and region. The country and region are each identified with 2 character codes")]
    public async Task<List<CountryRegionLocaleCasesTotalResponseModel>> GetTotalCasesForCountryRegionLocales(string countryCode, string regionCode)
    {
        return await covidDataClient.GetFinalCasesForCountryRegionLocales(countryCode, regionCode);
    }
}