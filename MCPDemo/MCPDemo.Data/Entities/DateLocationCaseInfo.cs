using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Data.Entities;

[PrimaryKey(nameof(Date), nameof(LocationKey))]
public class DateLocationCaseInfo
{
    [Key]
    public DateTime Date { get; set; }
    
    [Key]
    public required string LocationKey { get; set; }
    
    public int? NewConfirmedCases { get; set; }
    public int? NewDeceasedCases { get; set; }
    public int? NewRecoveredCases { get; set; }
    public int? NewTestsConducted { get; set; }
    
    public long? CumulativeConfirmedCases { get; set; }
    public long? CumulativeDeceasedCases { get; set; }
    public long? CumulativeRecoveredCases { get; set; }
    public long? CumulativeTestsConducted { get; set; }
}