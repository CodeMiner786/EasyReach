using EasyReach_Application.Interfaces.Repositories.Reviews;
using EasyReach_Domain.Entities.Reviews;
using EasyReach_Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Repositories.Reviews
{
    public class ProductReviewRepository(ApplicationDbContext context)
        : GenericRepository<ProductReview>(context), IProductReviewRepository
    {
    }
}
