using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.IRedis
{
    public interface ICacheLockManager
    {
        Task<string?> AcquireLockAsync(string resourceKey, TimeSpan expiration, CancellationToken cancellationToken = default);
        Task ReleaseLockAsync(string resourceKey, string lockToken, CancellationToken cancellationToken = default);
    }
}
