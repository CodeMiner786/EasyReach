using EasyReach_Application.CQRS.Querys.Wishlists;
using EasyReach_Application.DTOs.Wishlists;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Wishlists
{
    public class GetWishlistByUserIdQueryHandler(
        IWishlistRepository wishlistRepository,
        ICacheHelper cacheHelper) : IRequestHandler<GetWishlistByUserIdQuery, WishlistResponseDto?>
    {
        private readonly IWishlistRepository _wishlistRepository = wishlistRepository;
        private readonly ICacheHelper _cacheHelper = cacheHelper;

        public async Task<WishlistResponseDto?> Handle(GetWishlistByUserIdQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"wishlist:{request.UserId}";

            // 🚀 Redis Cache Check & Stampede Protection
            return await _cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var wishlistList = await _wishlistRepository.FindAsync(w => w.UserId == request.UserId);
                    var wishlist = wishlistList.FirstOrDefault();

                    if (wishlist == null) return null;

                    return new WishlistResponseDto
                    {
                        Id = wishlist.Id,
                        UserId = wishlist.UserId,
                        Items = [.. wishlist.Items.Select(item =>
                        {
                            // 🌟 IsDefault ভ্যারিয়েন্ট আগে নেবে, না থাকলে ১ম ভ্যারিয়েন্ট নেবে
                            var defaultVariant = item.Product?.Variants?.FirstOrDefault(v => v.IsDefault)
                                              ?? item.Product?.Variants?.FirstOrDefault();

                            // 🌟 Primary Image আগে নেবে, না থাকলে ১ম Image নেবে
                            var primaryImage = item.Product?.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                                              ?? item.Product?.Images?.FirstOrDefault()?.ImageUrl;

                            // 🌟 DiscountPrice থাকলে সেটা দেখাবে, না থাকলে RegularPrice
                            decimal finalPrice = defaultVariant?.DiscountPrice ?? defaultVariant?.RegularPrice ?? 0;

                            return new WishlistItemResponseDto
                            {
                                Id = item.Id,
                                ProductId = item.ProductId,
                                ProductName = item.Product?.Name ?? string.Empty,
                                ProductImageUrl = primaryImage,
                                Price = finalPrice,
                                AddedAt = item.AddedAt
                            };
                        })]
                    };
                },
                TimeSpan.FromMinutes(20)
            );
        }
    }
}
