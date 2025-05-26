using Microsoft.EntityFrameworkCore;

namespace MCPDemo.Data.ExtensionMethods;

public static class QueryableExtensionMethods
{
    public static async Task<List<T>> ToDistinctListAsync<T, TKey>(this IQueryable<T> source, Func<T, TKey> distinctSelector, CancellationToken cancellationToken = default)
    {
        // create the list
        var rawList = await source.ToListAsync(cancellationToken);
        return rawList.DistinctBy(distinctSelector).ToList();
    }
}