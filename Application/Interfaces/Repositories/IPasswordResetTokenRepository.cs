using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// PasswordResetToken er jonno specific repository contract. Common CRUD
    /// IGenericRepository&lt;PasswordResetToken&gt; theke pabe. "Forgot Password"
    /// flow e lagbe emon extra query (jemon GetValidTokenByTokenStringAsync)
    /// lagle eikhane add korte hobe.
    /// </summary>
    public interface IPasswordResetTokenRepository : IGenericRepository<PasswordResetToken>
    {
        Task<PasswordResetToken?> GetValidTokenAsync(string token);
    }
}
