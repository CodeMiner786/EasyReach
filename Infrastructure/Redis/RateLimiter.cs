using EasyReach_Application.IRedis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Redis
{
    public class RateLimiter(IConnectionMultiplexer redisConnection) : IRateLimiter
    {
        public async Task<bool> IsAllowedAsync(string key, int limit, TimeSpan window, CancellationToken cancellationToken = default)
        {
            var db = redisConnection.GetDatabase();
            string rateLimitKey = $"ratelimit:{key}";

            string luaScript = @"
                local current = redis.call('INCR', KEYS[1])
                if tonumber(current) == 1 then
                    redis.call('PEXPIRE', KEYS[1], ARGV[1])
                end
                return current";

            var result = await db.ExecuteAsync("EVAL", luaScript, 1, rateLimitKey, (long)window.TotalMilliseconds);
            long currentCount = (long)result;

            return currentCount <= limit;
        }

        public async Task ResetAsync(string key, CancellationToken cancellationToken = default)
        {
            var db = redisConnection.GetDatabase();
            string rateLimitKey = $"ratelimit:{key}";
            await db.KeyDeleteAsync(rateLimitKey);
        }
    }
}
