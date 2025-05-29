namespace MCPDemo.Data.Entities;

public class CountryRegionCasesTotal
{
    public required string CountryCode { get; set; }
    public required string SubRegion1Code { get; set; }
    public required string SubRegion1Name { get; set; }
    
    public required long CumulativeConfirmedCases { get; set; }
    public required long CumulativeDeceasedCases { get; set; }
    public required long CumulativeRecoveredCases { get; set; }
    public required long CumulativeTestsConducted { get; set; }
}