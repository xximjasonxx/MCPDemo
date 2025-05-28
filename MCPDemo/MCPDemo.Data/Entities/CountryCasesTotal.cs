namespace MCPDemo.Data.Entities;

public class CountryCasesTotal
{
    public required string CountryCode { get; set; }
    public required string CountryName { get; set; }
    
    public required long FinalConfirmedCases { get; set; }
    public required long FinalDeceasedCases { get; set; }
    public required long FinalRecoveredCases { get; set; }
    public required long FinalTestsConducted { get; set; }
}