using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Common;

namespace EasyReach_Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository Payments { get; }
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}