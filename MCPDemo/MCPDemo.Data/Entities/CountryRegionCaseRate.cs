namespace MCPDemo.Data.Entities;

public class CountryRegionCaseRate
{
    public required string CountryCode { get; set; }
    public required string CountryName { get; set; }
    public required string SubRegion1Code { get; set; }
    public required string SubRegion1Name { get; set; }
    public required string LocationKey { get; set; }
    public required string CurrentTimePeriod { get; set; }
    
    public decimal? NewCasesPercentageChange { get; set; }
    public decimal? NewDeceasedPercentageChange { get; set; }
    public decimal? NewRecoveredPercentageChange { get; set; }
}