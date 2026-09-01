using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class OrderItemRepository(ApplicationDbContext context) : GenericRepository<OrderItem>(context), IOrderItemRepository
    {
    }
}


// IOrderItemRepository er implementation. GenericRepository&lt;OrderItem&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e OrderItem-specific custom method thakle shegulo likha hobe.

