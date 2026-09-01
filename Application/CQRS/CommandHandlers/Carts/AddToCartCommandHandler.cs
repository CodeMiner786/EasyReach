using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.Exceptions;
using EasyReach_Application.Interfaces;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Carts;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Carts
{
    public class AddToCartCommandHandler(
        ICartRepository cartRepository,
        IGenericRepository<ProductVariant> variantRepository,
        ICacheHelper cacheHelper) : IRequestHandler<AddToCartCommand, bool>
    {
        public async Task<bool> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var variant = await variantRepository.GetByIdAsync(request.CartDto.ProductVariantId);

            if (variant is null || !variant.IsActive)
            {
                throw new ProductNotFoundException($"Product variant with ID '{request.CartDto.ProductVariantId}' is unavailable.");
            }

            var cartList = await cartRepository.FindAsync(c => c.UserId == request.UserId);
            var cart = cartList.FirstOrDefault();

            decimal currentPrice = variant.DiscountPrice ?? variant.RegularPrice;

            if (cart is null)
            {
                if (variant.StockQuantity < request.CartDto.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient stock. Available: {variant.StockQuantity}");
                }

                cart = new Cart
                {
                    UserId = request.UserId,
                    Items =
                    [
                        new CartItem
                        {
                            ProductVariantId = variant.Id,
                            Quantity = request.CartDto.Quantity,
                            UnitPriceSnapshot = currentPrice
                        }
                    ]
                };
                await cartRepository.AddAsync(cart);
            }
            else
            {
                var existingItem = cart.Items.FirstOrDefault(i => i.ProductVariantId == variant.Id);

                // 🛑 নতুন কোয়ান্টিটি সহ মোট স্টক চেক
                int newTotalQuantity = (existingItem?.Quantity ?? 0) + request.CartDto.Quantity;
                if (variant.StockQuantity < newTotalQuantity)
                {
                    throw new InvalidOperationException($"Insufficient stock. Requested total: {newTotalQuantity}, Available: {variant.StockQuantity}");
                }

                if (existingItem is not null)
                {
                    existingItem.Quantity = newTotalQuantity;
                    existingItem.UnitPriceSnapshot = currentPrice;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        CartId = cart.Id,
                        ProductVariantId = variant.Id,
                        Quantity = request.CartDto.Quantity,
                        UnitPriceSnapshot = currentPrice
                    });
                }
                cartRepository.Update(cart);
            }

            await cartRepository.SaveChangesAsync();
            await cacheHelper.RemoveAsync($"cart:{request.UserId}");
            return true;
        }
    }
}

