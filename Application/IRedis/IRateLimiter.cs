using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.IRedis
{
    public interface IRateLimiter
    {
        Task<bool> IsAllowedAsync(string key, int limit, TimeSpan window, CancellationToken cancellationToken = default);
        Task ResetAsync(string key, CancellationToken cancellationToken = default);
    }
}
