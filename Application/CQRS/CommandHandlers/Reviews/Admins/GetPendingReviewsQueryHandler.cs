using EasyReach_Application.CQRS.Querys.Reviews.Admins;
using EasyReach_Application.DTOs.Reviews;
using EasyReach_Application.Interfaces.Repositories.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Reviews.Admins
{
    public class GetPendingReviewsQueryHandler(IProductReviewRepository reviewRepository)
        : IRequestHandler<GetPendingReviewsQuery, List<ProductReviewResponseDto>>
    {
        public async Task<List<ProductReviewResponseDto>> Handle(GetPendingReviewsQuery request, CancellationToken cancellationToken)
        {
            var pendingReviews = await reviewRepository.FindAsync(r => !r.IsApproved);

            return [.. pendingReviews.Select(r => new ProductReviewResponseDto(
                r.Id,
                r.ProductId,
                r.UserId,
                r.User?.FullName ?? "Anonymous",
                r.Rating,
                r.Comment,
                r.IsVerifiedPurchase,
                r.CreatedAt
            )).OrderByDescending(r => r.CreatedAt)];
        }
    }
}
