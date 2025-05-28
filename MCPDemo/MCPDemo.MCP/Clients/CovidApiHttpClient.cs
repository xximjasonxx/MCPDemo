using MCPDemo.Common.ResponsModels;
using Newtonsoft.Json;

namespace MCPDemo.MCP.Clients;

public class CovidApiHttpClient(HttpClient httpClient) : ICovidApiClient
{
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        var response = await httpClient.GetAsync("/api/v1/countries");
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<List<CountryResponseModel>>(await response.Content.ReadAsStringAsync());
    }

    public async Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode)
    {
        var response = await httpClient.GetAsync($"/api/v1/country/{countryCode}/regions");
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<List<RegionResponseModel>>(await response.Content.ReadAsStringAsync());
    }

    public async Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode)
    {
        var response = await httpClient.GetAsync($"/api/v1/cases/country/{countryCode}/totals");
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<CountryCaseTotalResponseModel>(await response.Content.ReadAsStringAsync());
    }
}

public interface ICovidApiClient
{
    Task<List<CountryResponseModel>?> GetCountries();
    Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode);
    Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode);
}