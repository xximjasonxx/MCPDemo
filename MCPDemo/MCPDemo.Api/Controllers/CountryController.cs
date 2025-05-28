using MCPDemo.Common.ResponsModels;
using MCPDemo.Data;
using MCPDemo.Data.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class CountryController(IContext context) : ControllerBase
{
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await context.Locations
            .Where(x => string.IsNullOrEmpty(x.CountryCode) == false && string.IsNullOrEmpty(x.CountryName) == false)
            .Select(x => new CountryResponseModel(x.CountryCode, x.CountryName))
            .ToDistinctListAsync(x => x.CountryCode);
        
        return Ok(countries);
    }

    [HttpGet("country/{countryCode}")]
    public async Task<IActionResult> GetCountryByCountryCode(string countryCode)
    {
        if (string.IsNullOrEmpty(countryCode))
        {
            return BadRequest("Country Code is required");
        }

        var country = await context.Locations.FirstOrDefaultAsync(x => x.CountryCode == countryCode);
        if (country == null)
        {
            return NotFound();
        }
        
        return Ok(new CountryResponseModel(country.CountryCode, country.CountryName));
    }

    [HttpGet("country/{countryCode}/regions")]
    public async Task<IActionResult> GetRegionsByCountryCode(string countryCode)
    {
        if (string.IsNullOrEmpty(countryCode))
        {
            return BadRequest("Country Code is required");
        }

        var regions = await context.Locations
            .Where(x => x.CountryCode == countryCode && string.IsNullOrEmpty(x.SubRegion1Code) == false)
            .Select(x => new RegionResponseModel(x.SubRegion1Code, x.SubRegion1Name))
            .ToDistinctListAsync(x => x.RegionCode);
        
        return Ok(regions);
    }
}