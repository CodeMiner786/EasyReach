using EasyReach_Application.CQRS.Querys.Reviews;
using EasyReach_Application.DTOs.Reviews;
using EasyReach_Application.Interfaces.Repositories.Reviews;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Reviews
{
    public class GetProductReviewsQueryHandler(
        IProductReviewRepository reviewRepository,
        ICacheHelper cacheHelper)
        : IRequestHandler<GetProductReviewsQuery, ProductReviewSummaryDto>
    {
        public async Task<ProductReviewSummaryDto> Handle(GetProductReviewsQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"reviews:product:{request.ProductId}:p{request.PaginationParams.PageNumber}_s{request.PaginationParams.PageSize}";

            var result = await cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    // ১. নির্দিষ্ট প্রোডাক্টের অনুমোদিত রিভিউগুলোর পেজিনেশন ডাটা ফেচ
                    var pagedReviews = await reviewRepository.GetPagedAsync(
                        request.PaginationParams,
                        predicate: r => r.ProductId == request.ProductId && r.IsApproved,
                        orderBy: q => q.OrderByDescending(r => r.CreatedAt),
                        includeProperties: "User"
                    );

                    // রিভিউ না থাকলে ফাঁকা সামারি রিটার্ন
                    if (pagedReviews.TotalCount == 0)
                    {
                        var emptyPagedResult = new PagedResult<ProductReviewResponseDto>(
                            [], 0, request.PaginationParams.PageNumber, request.PaginationParams.PageSize);

                        return new ProductReviewSummaryDto(0, 0, 0, 0, 0, 0, 0, emptyPagedResult);
                    }

                    // ২. সামারি হিসাব করার জন্য ফিল্টার করা সম্পূর্ণ লিস্ট ফেচ
                    var allApprovedReviews = await reviewRepository.FindAsync(r => r.ProductId == request.ProductId && r.IsApproved);

                    double avgRating = Math.Round(allApprovedReviews.Average(r => r.Rating), 1);
                    int total = allApprovedReviews.Count;

                    // ৩. DTO ম্যাপ করা
                    var reviewDtos = pagedReviews.Items.Select(r => new ProductReviewResponseDto(
                        r.Id,
                        r.ProductId,
                        r.UserId,
                        r.User?.FullName ?? "Anonymous",
                        r.Rating,
                        r.Comment,
                        r.IsVerifiedPurchase,
                        r.CreatedAt
                    )).ToList();

                    var pagedReviewDtos = new PagedResult<ProductReviewResponseDto>(
                        reviewDtos,
                        pagedReviews.TotalCount,
                        pagedReviews.PageNumber,
                        pagedReviews.PageSize
                    );

                    return new ProductReviewSummaryDto(
                        avgRating,
                        total,
                        allApprovedReviews.Count(r => r.Rating == 5),
                        allApprovedReviews.Count(r => r.Rating == 4),
                        allApprovedReviews.Count(r => r.Rating == 3),
                        allApprovedReviews.Count(r => r.Rating == 2),
                        allApprovedReviews.Count(r => r.Rating == 1),
                        pagedReviewDtos
                    );
                },
                TimeSpan.FromMinutes(10)
            );

            return result ?? new ProductReviewSummaryDto(0, 0, 0, 0, 0, 0, 0,
                new PagedResult<ProductReviewResponseDto>([], 0, request.PaginationParams.PageNumber, request.PaginationParams.PageSize));
        }
    }
}

