namespace MCPDemo.Common.ResponsModels;

public record CountryResponseModel(string CountryCode, string CountryName);

public record RegionResponseModel(string RegionCode, string RegionName);

public record CountryCaseTotalResponseModel(
    string CountryCode,
    string CountryName,
    long TotalConfirmedCases,
    long TotalDeceasedCases,
    long TotalRecoveredCases,
    long TotalTestsConducted);
    
public record CountryRegionCasesTotalResponseModel(
    string CountryCode,
    string RegionCode,
    string RegionName,
    long TotalConfirmedCases,
    long TotalDeceasedCases,
    long TotalRecoveredCases,
    long TotalTestsConducted);