using MCPDemo.Common.ResponsModels;
using MCPDemo.Common.ResponsModels;

namespace MCPDemo.MCP.Interfaces;

public interface ICovidLocationDataClient
{
    Task<List<CountryResponseModel>?> GetCountries();
    Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode);
}