using EasyReach_Application.DTOs.Reviews;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Reviews
{
    public class GetProductReviewsQuery : IRequest<ProductReviewSummaryDto>
    {
        public Guid ProductId { get; set; }
        public PaginationParams PaginationParams { get; set; } = new();
    }
}
