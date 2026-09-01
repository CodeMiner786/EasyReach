using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class OrderStatusHistoryRepository(ApplicationDbContext context) : GenericRepository<OrderStatusHistory>(context), IOrderStatusHistoryRepository
    {
    }
}


// IOrderStatusHistoryRepository er implementation. GenericRepository&lt;OrderStatusHistory&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e OrderStatusHistory-specific custom method thakle shegulo likha hobe.

