using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCPDemo.Data.Entities;

[Table("Demographics")]
public class Demographic
{
    [Key]
    public required string LocationKey { get; set; }
    
    public int? TotalPopulation { get; set; }
    public int? MalePopulation { get; set; }
    public int? FemalePopulation { get; set; }
    public int? RuralPopulation { get; set; }
    public int? UrbanPopulation { get; set; }
    public int? LargestCityPopulation { get; set; }
    public int? ClusteredPopulation { get; set; }
    public decimal? PopulationPerSquareKilometer { get; set; }
    public decimal? HumanDevelopmentIndex { get; set; }
    
    public int? Population0To09 { get; set; }
    public int? Population10To19 { get; set; }
    public int? Population20To29 { get; set; }
    public int? Population30To39 { get; set; }
    public int? Population40To49 { get; set; }
    public int? Population50To59 { get; set; }
    public int? Population60To69 { get; set; }
    public int? Population70To79 { get; set; }
    public int? Population80Plus { get; set; }
}