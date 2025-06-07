using MCPDemo.Api.Services;
using MCPDemo.Data;
using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Operations;

public class GetCountryRegionsCaseTotalsOperation(IContext context, ICacheService cacheService) : IGetCountryRegionsCaseTotalsOperation
{
    public async Task<List<CountryRegionCasesTotal>> ExecuteAsync(string countryCode)
    {
        var cachedValue = await cacheService.GetValue<List<CountryRegionCasesTotal>>(GetKey(countryCode));
        if (cachedValue != null)
            return cachedValue;
        
        var results = await context.CountryRegionCasesTotal
            .Where(x => x.CountryCode == countryCode)
            .ToListAsync();
        
        Task.Run(() => cacheService.SaveValue(GetKey(countryCode), results, TimeSpan.FromHours(4)));
        return results;
    }
    
    string GetKey(string countryCode) => $"CountryRegionCasesTotal_{countryCode}";
}

public interface IGetCountryRegionsCaseTotalsOperation
{
    Task<List<CountryRegionCasesTotal>> ExecuteAsync(string countryCode);
}