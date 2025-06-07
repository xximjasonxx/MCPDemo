using MCPDemo.Api.Services;
using MCPDemo.Data;
using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Operations;

public class GetCountryRegionsCaseChangeRatesOperation(IContext context, ICacheService cacheService) : IGetCountryRegionsCaseChangeRatesOperation
{
    public async Task<List<CountryRegionCaseRate>> ExecuteAsync(string countryCode)
    {
        var cachedValue = await cacheService.GetValue<List<CountryRegionCaseRate>>(GetKey(countryCode));
        if (cachedValue != null)
            return cachedValue;
        
        var results = await context.CountryRegionCaseChangeRates
            .Where(x => x.CountryCode == countryCode)
            .ToListAsync();
            
        Task.Run(() => cacheService.SaveValue(GetKey(countryCode), results, TimeSpan.FromHours(4)));
        return results;
    }
    
    string GetKey(string countryCode) => $"CountryRegionCaseChangeRates_{countryCode}";
}

public interface IGetCountryRegionsCaseChangeRatesOperation
{
    Task<List<CountryRegionCaseRate>> ExecuteAsync(string countryCode);
}