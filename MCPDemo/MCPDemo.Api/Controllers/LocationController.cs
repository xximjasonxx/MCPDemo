using MCPDemo.Data;
using MCPDemo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MCPDemo.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class LocationController(IContext context) : ControllerBase
{
    [HttpGet("locations")]
    public async Task<IActionResult> GetLocations()
    {
        return Ok(await context.Locations.ToListAsync());
    }

    [HttpGet("location/{key}")]
    public async Task<IActionResult> GetLocation(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return BadRequest("Key is required");
        }
        
        var location = await context.Locations.FirstOrDefaultAsync(x => x.LocationKey.ToUpper() == key.ToUpper());
        if (location == null)
        {
            return NotFound();
        }

        return Ok(location);
    }
}