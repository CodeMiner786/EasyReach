using EasyReach_Application.CQRS.Commands.Wishlists;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Wishlists;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Wishlists
{
    public class AddToWishlistCommandHandler(
        IWishlistRepository wishlistRepository,
        IWishlistItemRepository wishlistItemRepository,
        ICacheHelper cacheHelper) : IRequestHandler<AddToWishlistCommand, bool>
    {
        public async Task<bool> Handle(AddToWishlistCommand request, CancellationToken cancellationToken)
        {
            // ১. ইউজারের উইশলিস্ট নিশ্চিত করা
            var wishlistList = await wishlistRepository.FindAsync(w => w.UserId == request.UserId);
            var wishlist = wishlistList.FirstOrDefault();

            if (wishlist == null)
            {
                wishlist = new Wishlist
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId
                };
                await wishlistRepository.AddAsync(wishlist);
                await wishlistRepository.SaveChangesAsync();
            }

            // ২. ডুপ্লিকেট চেক
            var existingItems = await wishlistItemRepository.FindAsync(
                i => i.WishlistId == wishlist.Id && i.ProductId == request.ProductId);

            if (existingItems.Count != 0)
            {
                return true; // ইতিমধ্যেই উইশলিস্টে বিদ্যমান
            }

            // ৩. নতুন আইটেম যুক্তকরণ
            var newItem = new WishlistItem
            {
                Id = Guid.NewGuid(),
                WishlistId = wishlist.Id,
                ProductId = request.ProductId,
                AddedAt = DateTime.UtcNow
            };

            await wishlistItemRepository.AddAsync(newItem);
            await wishlistItemRepository.SaveChangesAsync();

            // ⚡ ৪. Redis ক্যাশ ইনভ্যালিডেশন
            await cacheHelper.RemoveAsync($"wishlist:{request.UserId}");

            return true;
        }
    }
}

