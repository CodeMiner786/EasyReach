using EasyReach_Application.CQRS.Commands.Wishlists;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Wishlists
{
    public class RemoveFromWishlistCommandHandler(
        IWishlistRepository wishlistRepository,
        IWishlistItemRepository wishlistItemRepository,
        ICacheHelper cacheHelper) : IRequestHandler<RemoveFromWishlistCommand, bool>
    {
        private readonly IWishlistRepository _wishlistRepository = wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository = wishlistItemRepository;
        private readonly ICacheHelper _cacheHelper = cacheHelper;

        public async Task<bool> Handle(RemoveFromWishlistCommand request, CancellationToken cancellationToken)
        {
            var wishlistList = await _wishlistRepository.FindAsync(w => w.UserId == request.UserId);
            var wishlist = wishlistList.FirstOrDefault();

            if (wishlist == null) return false;

            var items = await _wishlistItemRepository.FindAsync(
                i => i.WishlistId == wishlist.Id && i.ProductId == request.ProductId);

            var itemToRemove = items.FirstOrDefault();
            if (itemToRemove == null) return false;

            _wishlistItemRepository.Remove(itemToRemove);
            await _wishlistItemRepository.SaveChangesAsync();

            // ⚡ Redis ক্যাশ ক্লিয়ার করা
            await _cacheHelper.RemoveAsync($"wishlist:{request.UserId}");

            return true;
        }
    }
}
