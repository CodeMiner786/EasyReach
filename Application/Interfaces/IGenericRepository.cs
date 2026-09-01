using EasyReach_Domain.Common;
using EasyReach_Domain.Common.Paginations;
using System.Linq.Expressions;

namespace EasyReach_Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

        // ---------- Pagination Specific ----------
        Task<PagedResult<T>> GetPagedAsync(
            PaginationParams paginationParams,
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        // ---------- Soft Delete specific ----------
        Task<List<T>> GetAllIncludingDeletedAsync();

        Task<List<T>> GetDeletedAsync();

        void Restore(T entity);

        Task<int> SaveChangesAsync();
    }
}

