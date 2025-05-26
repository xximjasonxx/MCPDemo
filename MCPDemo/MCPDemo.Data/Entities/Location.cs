using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCPDemo.Data.Entities;

[Table("Locations")]
public class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string LocationKey { get; set; }
    
    public string? PlaceId { get; set; }
    
    public required string CountryCode { get; set; }
    
    public required string CountryName { get; set; }
    
    public string? SubRegion1Code { get; set; }

    public string? SubRegion2Code { get; set; }
}