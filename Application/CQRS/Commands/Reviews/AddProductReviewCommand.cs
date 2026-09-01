using EasyReach_Application.DTOs.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Reviews
{
    public record AddProductReviewCommand(Guid UserId, AddReviewDto ReviewDto) : IRequest<bool>;
}
