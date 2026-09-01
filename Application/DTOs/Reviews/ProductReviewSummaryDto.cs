using EasyReach_Domain.Common.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Reviews
{
    public record ProductReviewSummaryDto(
        double AverageRating,
        int TotalReviews,
        int FiveStarCount,
        int FourStarCount,
        int ThreeStarCount,
        int TwoStarCount,
        int OneStarCount,
        PagedResult<ProductReviewResponseDto> PagedReviews
    );
}
