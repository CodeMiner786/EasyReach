using EasyReach_Application.CQRS.Commands.Reviews.Admins;
using EasyReach_Application.Interfaces.Repositories.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Reviews.Admins
{
    public class ApproveReviewCommandHandler(IProductReviewRepository reviewRepository)
        : IRequestHandler<ApproveReviewCommand, bool>
    {
        public async Task<bool> Handle(ApproveReviewCommand request, CancellationToken cancellationToken)
        {
            var reviews = await reviewRepository.FindAsync(r => r.Id == request.ReviewId);
            var review = reviews.FirstOrDefault() ?? throw new KeyNotFoundException("Review not found.");
            review.IsApproved = request.IsApproved;
            review.UpdatedAt = DateTime.UtcNow;

            reviewRepository.Update(review); // 👈 Fix: UpdateAsync -> Update
            await reviewRepository.SaveChangesAsync();

            return true;
        }
    }
}