using EasyReach_Application.IRedis;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Redis
{
    public class RedisCacheService(IDistributedCache distributedCache, IConnectionMultiplexer redisConnection) : ICacheService
    {
        private readonly IDistributedCache _cache = distributedCache;
        private readonly IConnectionMultiplexer _redisConnection = redisConnection;

        public async Task<T?> GetAsync<T>(string key)
        {
            var cachedData = await _cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cachedData)) return default;
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10)
            };
            var serializedData = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, serializedData, options);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task RemoveByPrefixAsync(string prefixKey)
        {
            var endpoints = _redisConnection.GetEndPoints();
            var server = _redisConnection.GetServer(endpoints.First());
            var db = _redisConnection.GetDatabase();

            string searchPattern = $"*{prefixKey}*";

            await foreach (var key in server.KeysAsync(pattern: searchPattern))
            {
                await db.KeyDeleteAsync(key);
            }
        }
    }
}
