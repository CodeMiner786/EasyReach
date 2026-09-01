using EasyReach_Domain.Entities.LandingPages;

namespace EasyReach_Application.Interfaces.Repositories.LandingPages
{
    public interface ILandingPageRepository : IGenericRepository<LandingPage>
    {
        Task<List<LandingPage>> GetPublishedWithProductsAsync();
        Task<LandingPage?> GetBySlugWithProductsAsync(string slug);
        Task<LandingPage?> GetByIdWithProductsAsync(Guid id);
    }
}

