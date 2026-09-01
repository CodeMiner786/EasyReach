using EasyReach_Application.CQRS.Commands.Reviews;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.Reviews;
using EasyReach_Domain.Entities.Reviews;
using EasyReach_Domain.Enums;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Reviews
{
    public class AddProductReviewCommandHandler(
        IProductReviewRepository reviewRepository,
        IOrderRepository orderRepository) : IRequestHandler<AddProductReviewCommand, bool>
    {
        public async Task<bool> Handle(AddProductReviewCommand request, CancellationToken cancellationToken)
        {
            // ১. কাস্টমার প্রোডাক্টটি ক্রয় করেছে এবং ডেলিভারি পেয়েছে কিনা চেক করা
            var userOrders = await orderRepository.FindAsync(o =>
                o.UserId == request.UserId &&
                o.Status == OrderStatus.Delivered);

            bool isVerified = false;

            if (userOrders.Count != 0)
            {
                // ProductVariant -> ProductId ব্যবহার করে ভ্যালিডেশন চেক করা হচ্ছে
                isVerified = userOrders.Exists(o =>
                    o.Items != null && o.Items.Any(i => i.ProductVariant != null && i.ProductVariant.ProductId == request.ReviewDto.ProductId)
                );
            }

            // ২. ডুপ্লিকেট রিভিউ রোধ করা (Count != 0 ব্যবহার করে Perf Warning দূর করা হলো)
            var existingReviews = await reviewRepository.FindAsync(r =>
                r.UserId == request.UserId && r.ProductId == request.ReviewDto.ProductId);

            if (existingReviews.Count != 0)
            {
                throw new InvalidOperationException("You have already reviewed this product.");
            }

            // ৩. রিভিউ সেভ করা
            var review = new ProductReview
            {
                Id = Guid.NewGuid(),
                ProductId = request.ReviewDto.ProductId,
                UserId = request.UserId,
                Rating = Math.Clamp(request.ReviewDto.Rating, 1, 5),
                Comment = request.ReviewDto.Comment,
                IsApproved = false,
                IsVerifiedPurchase = isVerified,
                CreatedAt = DateTime.UtcNow
            };

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveChangesAsync();

            return true;
        }
    }
}

