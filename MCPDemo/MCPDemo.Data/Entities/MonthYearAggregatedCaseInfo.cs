namespace MCPDemo.Data.Entities;

public class MonthYearAggregatedCaseInfo
{
    public required string TimePeriod { get; set; }
    public required string LocationKey { get; set; }
    public required int NewConfirmedCases { get; set; }
    public required int NewDeceasedCases { get; set; }
    public required int NewRecoveredCases { get; set; }
}