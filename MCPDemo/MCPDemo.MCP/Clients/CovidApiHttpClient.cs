using MCPDemo.Api.Models;
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
}

public interface ICovidApiClient
{
    Task<List<CountryResponseModel>?> GetCountries();
}