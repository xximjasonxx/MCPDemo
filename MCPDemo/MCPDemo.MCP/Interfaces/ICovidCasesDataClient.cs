using MCPDemo.Common.ResponsModels;

namespace MCPDemo.MCP.Interfaces;

public interface ICovidCasesDataClient
{
    Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode);
    Task<List<CountryCaseTotalResponseModel>> GetFinalCasesForAllCountries();
    Task<List<CountryRegionCasesTotalResponseModel>> GetFinalCasesForCountryRegions(string countryCode);
    Task<List<CountryRegionLocaleCasesTotalResponseModel>> GetFinalCasesForCountryRegionLocales(string countryCode, string regionCode);
}