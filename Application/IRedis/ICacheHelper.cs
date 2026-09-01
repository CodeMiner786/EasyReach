using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.IRedis
{
    public interface ICacheHelper
    {
        // ১. ক্যাশ থেকে ডাটা নেওয়া, না থাকলে ডাটাবেজ থেকে এনে সেভ করা (Cache Stampede Safety সহ)
        Task<T?> GetOrSetAsync<T>(string cacheKey, Func<Task<T?>> factory, TimeSpan? expiration = null);

        // ২. নির্দিষ্ট একটি Key-এর ক্যাশ মুছে দেওয়া
        Task RemoveAsync(string key);

        // ৩. নির্দিষ্ট Prefix বা নামের শুরু মিলিয়ে সব ক্যাশ মুছে দেওয়া (যেমন: product:*)
        Task RemoveByPrefixAsync(string prefixKey);

        // ৪. এডমিন ড্যাশবোর্ডের ডাটা ক্যাশে সেট করা
        Task SetAdminStatsAsync<T>(string statsKey, T data, TimeSpan? expiration = null);

        // ৫. এডমিন ড্যাশবোর্ডের জমে থাকা সব ক্যাশ এক ক্লিকে মুছে দেওয়া
        Task InvalidateAdminDashboardCacheAsync();
    }
}
