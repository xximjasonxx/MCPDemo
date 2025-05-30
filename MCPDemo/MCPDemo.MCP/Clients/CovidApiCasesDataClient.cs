using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Interfaces;

namespace MCPDemo.MCP.Clients;

public class CovidCasesDataCasesDataClient(HttpClient httpClient) : ClientBase(httpClient), ICovidCasesDataClient
{
    public async Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode)
    {
        return await InvokeGetRequest<CountryCaseTotalResponseModel?>($"/api/v1/cases/country/{countryCode}/totals");
    }

    public async Task<List<CountryCaseTotalResponseModel>> GetFinalCasesForAllCountries()
    {
        return await InvokeGetRequest<List<CountryCaseTotalResponseModel>>(@"api/v1/cases/country/totals");
    }

    public async Task<List<CountryRegionCasesTotalResponseModel>> GetFinalCasesForCountryRegions(string countryCode)
    {
        return await InvokeGetRequest<List<CountryRegionCasesTotalResponseModel>>($"/api/v1/cases/country/{countryCode}/regions/totals");
    }

    public async Task<List<CountryRegionLocaleCasesTotalResponseModel>> GetFinalCasesForCountryRegionLocales(string countryCode, string regionCode)
    {
        return await InvokeGetRequest<List<CountryRegionLocaleCasesTotalResponseModel>>(
            uriPart: $"api/cases/country/{countryCode}/regions/{regionCode}/locales/totals");
    }
}