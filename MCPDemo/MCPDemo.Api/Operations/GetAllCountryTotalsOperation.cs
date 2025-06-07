using MCPDemo.Api.Services;
using MCPDemo.Data;
using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Api.Operations;

public class GetAllCountryTotalsOperation(IContext context, ICacheService cacheService) : IGetAllCountryTotalsOperation
{
    public async Task<List<CountryCasesTotal>> ExecuteAsync()
    {
        var cachedValue = await cacheService.GetValue<List<CountryCasesTotal>>(GetKey());
        if (cachedValue != null)
            return cachedValue;
        
        var results = await context.CountryCasesTotal.ToListAsync();
        Task.Run(() => cacheService.SaveValue(GetKey(), results, TimeSpan.FromHours(4)));
        return results;
    }
    
    string GetKey() => $"AllCountryCasesTotal";
}

public interface IGetAllCountryTotalsOperation
{
    Task<List<CountryCasesTotal>> ExecuteAsync();
}