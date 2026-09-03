using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Interfaces.Repositories
{
    public interface IPageRepository : IGenericRepository<Page>
    {
        Task<Page?> GetPageWithDetailsBySlugAsync(string slug);
        Task<List<Page>> GetAllWithDetailsAsync(); // এটি যোগ করুন
    }
}
