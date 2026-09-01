using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Reviews.Admins
{
    public record ApproveReviewCommand(Guid ReviewId, bool IsApproved) : IRequest<bool>;
    public record DeleteReviewCommand(Guid ReviewId) : IRequest<bool>;
}
