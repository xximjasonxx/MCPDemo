using MCPDemo.Data.Entities;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MCPDemo.Api.Services;

public class RedisCacheService : ICacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _redisDatabase;

    public RedisCacheService(IConfiguration configuration)
    {
        _redis = ConnectionMultiplexer.Connect(configuration["RedisConnectionString"]);
        _redisDatabase = _redis.GetDatabase();
    }
    
    public async Task<T?> GetValue<T>(string key)
    {
        var value = await _redisDatabase.StringGetAsync(new RedisKey(key));
        if (value.HasValue == false)
            return default;
        
        return JsonConvert.DeserializeObject<T>(value.ToString());
    }

    public async Task SaveValue(string key, object value, TimeSpan timeToLive)
    {
        var stringValue = JsonConvert.SerializeObject(value);
        await _redisDatabase.StringSetAsync(new RedisKey(key), stringValue, timeToLive);
    }
}

public interface ICacheService
{
    Task<T?> GetValue<T>(string key);
    Task SaveValue(string key, object value, TimeSpan timeToLive);
}