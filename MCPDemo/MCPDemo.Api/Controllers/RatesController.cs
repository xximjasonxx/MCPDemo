using System.Globalization;
using MCPDemo.Api.Operations;
using MCPDemo.Common.ResponsModels;
using MCPDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class RatesController : ControllerBase
{
    private readonly IContext _context;
    private readonly IGetCountryRegionsCaseChangeRatesOperation _getCountryRegionsCaseChangeRatesOperation;
    public RatesController(IContext context, IGetCountryRegionsCaseChangeRatesOperation getCountryRegionsCaseChangeRatesOperation)
    {
        _context = context;
        _getCountryRegionsCaseChangeRatesOperation = getCountryRegionsCaseChangeRatesOperation;
    }
    
    [HttpGet("rates/country/{countryCode}")]
    public async Task<IActionResult> GetCountryCaseRate(string countryCode)
    {
        var results = await _context.CountryCaseChangeRates
            .Where(x => x.CountryCode == countryCode)
            .ToListAsync();
        
        if (results.Any() == false)
            return NotFound();
        
        return Ok(results.Select(x => new CountryCaseChangeRateResponseModel(
            x.CountryCode,
            x.CountryName,
            DateTime.ParseExact(x.CurrentTimePeriod + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
            (x.NewCasesPercentageChange ?? 0) / 100,
            (x.NewDeceasedPercentageChange ?? 0) / 100,
            (x.NewRecoveredPercentageChange ?? 0) / 100
        )).OrderBy(x => x.MonthYear));
    }
    
    [HttpGet("rates/country/{countryCode}/regions")]
    public async Task<IActionResult> GetCountryRegionCaseRate(string countryCode)
    {
        var results = await _getCountryRegionsCaseChangeRatesOperation.ExecuteAsync(countryCode);
        if (results.Any() == false)
            return NotFound();

        return Ok(results.Select(x => new CountryRegionCaseChangeRateResponseModel(
            x.CountryCode,
            x.CountryName,
            x.SubRegion1Code,
            x.SubRegion1Name,
            DateTime.ParseExact(x.CurrentTimePeriod + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
            (x.NewCasesPercentageChange ?? 0) / 100,
            (x.NewDeceasedPercentageChange ?? 0) / 100,
            (x.NewRecoveredPercentageChange ?? 0) / 100)));
    }
}