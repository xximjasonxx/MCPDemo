using MCPDemo.Api.Services;
using MCPDemo.Data;
using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Operations;

public class GetCountryCaseChangeRatesOperation(IContext context, ICacheService cacheService) : IGetCountryCaseChangeRatesOperation
{
    public async Task<List<CountryCaseRate>> ExecuteAsync(string countryCode)
    {
        var cachedValue = await cacheService.GetValue<List<CountryCaseRate>>(GetKey(countryCode));
        if (cachedValue != null)
            return cachedValue;
        
        var results = await context.CountryCaseChangeRates
            .Where(x => x.CountryCode == countryCode)
            .ToListAsync();
        Task.Run(() => cacheService.SaveValue(GetKey(countryCode), results, TimeSpan.FromHours(4)));
        return results;
    }
    
    string GetKey(string countryCode) => $"CountryCaseChangeRates_{countryCode}";
}

public interface IGetCountryCaseChangeRatesOperation
{
    Task<List<CountryCaseRate>> ExecuteAsync(string countryCode);
}