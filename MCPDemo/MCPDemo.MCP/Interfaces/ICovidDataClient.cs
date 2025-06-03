using MCPDemo.Common.ResponsModels;

namespace MCPDemo.MCP.Interfaces;

public interface ICovidDataClient
{
    Task<CountryCaseTotalResponseModel?> GetFinalCasesForCountry(string countryCode);
    Task<List<CountryCaseTotalResponseModel>> GetFinalCasesForAllCountries();
    Task<List<CountryRegionCasesTotalResponseModel>> GetFinalCasesForCountryRegions(string countryCode);
    Task<List<CountryRegionLocaleCasesTotalResponseModel>> GetFinalCasesForCountryRegionLocales(string countryCode, string regionCode);
    Task<List<CountryResponseModel>?> GetCountries();
    Task<List<RegionResponseModel>?> GetRegionsForCountry(string countryCode);
    Task<List<CountryCaseChangeRateResponseModel>> GetCountryCaseChangeRates(string countyCode);
}