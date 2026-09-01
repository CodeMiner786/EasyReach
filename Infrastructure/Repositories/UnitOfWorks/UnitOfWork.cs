using EasyReach_Application.Interfaces;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.UnitOfWorks;
using EasyReach_Domain.Common;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;

namespace EasyReach_Infrastructure.Repositories.UnitOfWorks
{
    public class UnitOfWork(
        ApplicationDbContext context,
        IPaymentRepository paymentRepository) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;
        private IDbContextTransaction? _currentTransaction;
        private readonly ConcurrentDictionary<string, object> _repositories = new();

        public IPaymentRepository Payments { get; } = paymentRepository;

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var typeName = typeof(T).Name;

            return (IGenericRepository<T>)_repositories.GetOrAdd(typeName, _ =>
                new GenericRepository<T>(_context));
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        // ১. ট্রানজেকশন শুরু করার মেথড (কোর EF Core Transaction লুকিয়ে রাখছে)
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        // ২. ট্রানজেকশন সফলভাবে শেষ করার মেথড (Save + Commit)
        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync(cancellationToken);
                }
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        // ৩. কোনো সমস্যা হলে ট্রানজেকশন রোলব্যাক করার মেথড
        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.RollbackAsync(cancellationToken);
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            _currentTransaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
