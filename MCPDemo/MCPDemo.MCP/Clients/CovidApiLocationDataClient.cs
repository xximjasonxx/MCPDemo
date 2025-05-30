using MCPDemo.MCP.Interfaces;
using MCPDemo.Common.ResponsModels;

namespace MCPDemo.MCP.Clients;

public class CovidApiLocationDataClient(HttpClient httpClient) : ClientBase(httpClient), ICovidLocationDataClient
{
    public async Task<List<CountryResponseModel>?> GetCountries()
    {
        return await InvokeGetRequest<List<CountryResponseModel>>("api/v1/countries");
    }

    public async Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode)
    {
        return await InvokeGetRequest<List<RegionResponseModel>>($"api/v1/country/{countryCode}/regions");
    }
}