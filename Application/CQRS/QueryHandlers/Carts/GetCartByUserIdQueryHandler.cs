using EasyReach_Application.CQRS.Querys.Carts;
using EasyReach_Application.DTOs.Carts;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Carts
{
    public class GetCartByUserIdQueryHandler(
        ICartRepository cartRepository,
        ICacheHelper cacheHelper) : IRequestHandler<GetCartByUserIdQuery, CartResponseDto?>
    {
        private readonly ICartRepository _cartRepository = cartRepository;
        private readonly ICacheHelper _cacheHelper = cacheHelper;

        public async Task<CartResponseDto?> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"cart:{request.UserId}";

            return await _cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var cartList = await _cartRepository.FindAsync(c => c.UserId == request.UserId);
                    var cart = cartList.FirstOrDefault();

                    if (cart == null || cart.Items == null || cart.Items.Count == 0) return null;

                    var response = new CartResponseDto
                    {
                        Id = cart.Id,
                        UserId = cart.UserId,
                        Items = [.. cart.Items.Select(item =>
                        {
                            var variant = item.ProductVariant;
                            var product = variant?.Product;
                            var primaryImage = product?.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                                              ?? product?.Images?.FirstOrDefault()?.ImageUrl;

                            return new CartItemResponseDto
                            {
                                Id = item.Id,
                                ProductVariantId = item.ProductVariantId,
                                ProductId = variant?.ProductId ?? Guid.Empty,
                                ProductName = product?.Name ?? string.Empty,
                                VariantName = variant?.VariantName ?? string.Empty,
                                ProductImageUrl = primaryImage,
                                UnitPriceSnapshot = item.UnitPriceSnapshot,
                                Quantity = item.Quantity,
                                AvailableStock = variant?.StockQuantity ?? 0
                            };
                        })]
                    };

                    response.TotalAmount = response.Items.Sum(x => x.SubTotal);
                    return response;
                },
                TimeSpan.FromMinutes(30)
            );
        }
    }
}
