using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Interfaces;

namespace MCPDemo.MCP.Clients;

public class CovidApiDataClient(HttpClient httpClient) : ClientBase(httpClient), ICovidDataClient
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
        Console.WriteLine("Invoking GetFinalCasesForCountryRegionLocales");
        return await InvokeGetRequest<List<CountryRegionLocaleCasesTotalResponseModel>>(
            uriPart: $"api/cases/country/{countryCode}/regions/{regionCode}/locales/totals");
    }
    
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        Console.WriteLine("Invoking GetCountries");
        return await InvokeGetRequest<List<CountryResponseModel>>("api/v1/countries");
    }

    public async Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode)
    {
        return await InvokeGetRequest<List<RegionResponseModel>>($"api/v1/country/{countryCode}/regions");
    }
}