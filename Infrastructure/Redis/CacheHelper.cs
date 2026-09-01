using EasyReach_Application.IRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Redis
{
    public class CacheHelper(ICacheService cacheService, ICacheLockManager lockManager) : ICacheHelper
    {
        private readonly ICacheService _cache = cacheService;
        private readonly ICacheLockManager _lockManager = lockManager;

        // ১. GetOrSetAsync (স্মার্ট ক্যাশিং লজিক)
        public async Task<T?> GetOrSetAsync<T>(
            string cacheKey,
            Func<Task<T?>> factory,
            TimeSpan? expiration = null)
        {
            // ক. প্রথমে ক্যাশ চেক করো
            var cached = await _cache.GetAsync<T>(cacheKey);
            if (cached is not null) return cached;

            int maxRetries = 5;
            int retryDelayMs = 200;

            // খ. ক্যাশে না থাকলে ডিস্ট্রিবিউটেড লক নিয়ে একজন ডাটাবেজে যাবে, বাকিরা ওয়েট করবে
            for (int i = 0; i < maxRetries; i++)
            {
                cached = await _cache.GetAsync<T>(cacheKey);
                if (cached is not null) return cached;

                string? lockToken = await _lockManager.AcquireLockAsync(cacheKey, TimeSpan.FromSeconds(5));

                if (lockToken is not null)
                {
                    try
                    {
                        cached = await _cache.GetAsync<T>(cacheKey);
                        if (cached is not null) return cached;

                        // ডাটাবেজ থেকে ডাটা আনো
                        var data = await factory();
                        if (data is not null)
                        {
                            await _cache.SetAsync(cacheKey, data, expiration);
                        }
                        return data;
                    }
                    finally
                    {
                        await _lockManager.ReleaseLockAsync(cacheKey, lockToken);
                    }
                }

                await Task.Delay(retryDelayMs);
            }

            return await factory();
        }

        // ২. সিঙ্গেল ক্যাশ ডিলিট
        public async Task RemoveAsync(string key)
            => await _cache.RemoveAsync(key);

        // ৩. প্রিফিক্স দিয়ে গ্রুপ ক্যাশ ডিলিট
        public async Task RemoveByPrefixAsync(string prefixKey)
            => await _cache.RemoveByPrefixAsync(prefixKey);

        // ৪. এডমিন ড্যাশবোর্ডের ডাটা ক্যাশে রাখা (ডিফল্ট ১৫ মিনিট)
        public async Task SetAdminStatsAsync<T>(string statsKey, T data, TimeSpan? expiration = null)
        {
            string fullKey = $"admin:stats:{statsKey}";
            await _cache.SetAsync(fullKey, data, expiration ?? TimeSpan.FromMinutes(15));
        }

        // ৫. এডমিন ড্যাশবোর্ডের সব ক্যাশ মুছে ফেলা
        public async Task InvalidateAdminDashboardCacheAsync()
        {
            await _cache.RemoveByPrefixAsync("admin:stats");
        }
    }
}
