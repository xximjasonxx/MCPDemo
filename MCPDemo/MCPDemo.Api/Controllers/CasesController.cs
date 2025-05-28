using MCPDemo.Common.ResponsModels;
using MCPDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Controllers;

[ApiController]
[Route("api/vi/[controller]")]
public class CasesController(IContext context) : ControllerBase
{
    [HttpGet("country/{countryCode}/totals")]
    public async Task<IActionResult> GetCountryCaseTotalsAsync(string countryCode)
    {
        if (string.IsNullOrEmpty(countryCode))
        {
            return BadRequest("Country Code is required.");
        }
        
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
}