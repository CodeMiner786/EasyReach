using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// RefreshToken er jonno specific repository contract. Common CRUD
    /// IGenericRepository&lt;RefreshToken&gt; theke pabe. Login/Logout/Token-Refresh
    /// flow e lagbe emon extra query (jemon GetByTokenAsync, RevokeAllByUserIdAsync)
    /// lagle eikhane add korte hobe.
    /// </summary>
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task RevokeAllUserTokensAsync(Guid userId, string revokedByIp);
    }
}
