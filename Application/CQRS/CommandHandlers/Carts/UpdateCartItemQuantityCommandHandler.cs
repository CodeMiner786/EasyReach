using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.Interfaces;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Carts
{
    public class UpdateCartItemQuantityCommandHandler(
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IGenericRepository<ProductVariant> variantRepository,
        ICacheHelper cacheHelper) : IRequestHandler<UpdateCartItemQuantityCommand, bool>
    {
        public async Task<bool> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var cartList = await cartRepository.FindAsync(c => c.UserId == request.UserId);
            var cart = cartList.FirstOrDefault();
            if (cart is null) return false;

            var item = cart.Items.FirstOrDefault(i => i.Id == request.Dto.CartItemId);
            if (item is null) return false;

            if (request.Dto.Quantity <= 0)
            {
                cartItemRepository.Remove(item);
            }
            else
            {
                // 🛑 কোয়ান্টিটি বাড়ানোর সময় ডাটাবেজ থেকে স্টক রি-ভ্যালিডেট
                var variant = await variantRepository.GetByIdAsync(item.ProductVariantId);
                if (variant is null || variant.StockQuantity < request.Dto.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient stock for requested quantity. Available stock: {variant?.StockQuantity ?? 0}");
                }

                item.Quantity = request.Dto.Quantity;
                cartItemRepository.Update(item);
            }

            await cartItemRepository.SaveChangesAsync();
            await cacheHelper.RemoveAsync($"cart:{request.UserId}");
            return true;
        }
    }
}

