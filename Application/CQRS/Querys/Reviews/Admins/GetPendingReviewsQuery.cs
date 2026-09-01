using EasyReach_Application.DTOs.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Reviews.Admins
{
    public record GetPendingReviewsQuery() : IRequest<List<ProductReviewResponseDto>>;
}
