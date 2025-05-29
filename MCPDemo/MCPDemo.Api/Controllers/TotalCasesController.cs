using MCPDemo.Common.ResponsModels;
using MCPDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Controllers;

[ApiController]
[Route("api/v1/cases")]
public class TotalCasesController(IContext context) : ControllerBase
{
    [HttpGet("country/{countryCode}/totals")]
    public async Task<IActionResult> GetCountryCaseTotalsAsync(string countryCode)
    {
        var result = await context.CountryCasesTotal
            .FirstOrDefaultAsync(x => x.CountryCode == countryCode);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(new CountryCaseTotalResponseModel(
            result.CountryCode,
            result.CountryName,
            result.FinalConfirmedCases,
            result.FinalDeceasedCases,
            result.FinalRecoveredCases,
            result.FinalTestsConducted));
    }

    [HttpGet("country/totals")]
    public async Task<IActionResult> GetCountryTotalsAsync(string countryCode)
    {
        var results = await context.CountryCasesTotal.ToListAsync();

        return Ok(results.Select(x => new CountryCaseTotalResponseModel(
            x.CountryCode,
            x.CountryName,
            x.FinalConfirmedCases,
            x.FinalDeceasedCases,
            x.FinalRecoveredCases,
            x.FinalTestsConducted)));
    }

    [HttpGet("country/{countryCode}/regions/totals")]
    public async Task<IActionResult> GetCountryCaseRegionTotalsAsync(string countryCode)
    {
        var results = await context.CountryRegionCasesTotal
            .Where(x => x.CountryCode == countryCode)
            .ToListAsync();

        if (results.Count == 0)
        {
            return NotFound();
        }

        return Ok(results.Select(x => new CountryRegionCasesTotalResponseModel(
            x.CountryCode,
            x.SubRegion1Code,
            x.SubRegion1Name,
            x.CumulativeConfirmedCases,
            x.CumulativeDeceasedCases,
            x.CumulativeRecoveredCases,
            x.CumulativeTestsConducted)));
    }

    [HttpGet("country/{countryCode}/regions/{regionCode}/totals")]
    public async Task<IActionResult> GetCountryCaseRegionTotalsAsync(string countryCode, string regionCode)
    {
        var result = await context.CountryRegionCasesTotal
            .FirstOrDefaultAsync(x => x.CountryCode == countryCode && x.SubRegion1Code == regionCode);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(new CountryRegionCasesTotalResponseModel(
            result.CountryCode,
            result.SubRegion1Code,
            result.SubRegion1Name,
            result.CumulativeConfirmedCases,
            result.CumulativeDeceasedCases,
            result.CumulativeRecoveredCases,
            result.CumulativeTestsConducted));
    }
}