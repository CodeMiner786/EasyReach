using EasyReach_Application.IRedis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Redis
{
    public class CacheLockManager(IConnectionMultiplexer redisConnection) : ICacheLockManager
    {
        public async Task<string?> AcquireLockAsync(string resourceKey, TimeSpan expiration, CancellationToken cancellationToken = default)
        {
            var db = redisConnection.GetDatabase();
            string lockKey = $"lock:{resourceKey}";
            string token = Guid.NewGuid().ToString();

            bool acquired = await db.StringSetAsync(lockKey, token, expiration, When.NotExists);
            return acquired ? token : null;
        }

        public async Task ReleaseLockAsync(string resourceKey, string lockToken, CancellationToken cancellationToken = default)
        {
            var db = redisConnection.GetDatabase();
            string lockKey = $"lock:{resourceKey}";

            string luaScript = @"
                if redis.call('get', KEYS[1]) == ARGV[1] then
                    return redis.call('del', KEYS[1])
                else
                    return 0
                end";

            await db.ExecuteAsync("EVAL", luaScript, 1, lockKey, lockToken);
        }
    }
}
