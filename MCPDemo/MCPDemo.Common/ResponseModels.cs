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
    
public record CountryRegionLocaleCasesTotalResponseModel(
    string CountryCode,
    string RegionCode,
    string LocaleCode,
    string LocaleName,
    long TotalConfirmedCases,
    long TotalDeceasedCases,
    long TotalRecoveredCases,
    long TotalTestsConducted);

public record CountryCaseChangeRateResponseModel(
    string CountryCode,
    string CountryName,
    DateTime MonthYear,
    decimal? ConfirmedCasesChangeRate,
    decimal? DeceasedCasesChangeRate,
    decimal? RecoveredCasesChangeRate);
    
public record CountryRegoionCaseChangeRateResponseModel(
    string CountryCode,
    string CountryName,
    string RegionCode,
    string RegionName,
    DateTime MonthYear,
    decimal? ConfirmedCasesChangeRate,
    decimal? DeceasedCasesChangeRate,
    decimal? RecoveredCasesChangeRate);