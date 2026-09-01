using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Carts
{
    public class RemoveFromCartCommandHandler(
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        ICacheHelper cacheHelper) : IRequestHandler<RemoveFromCartCommand, bool>
    {
        public async Task<bool> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartList = await cartRepository.FindAsync(c => c.UserId == request.UserId);
            var cart = cartList.FirstOrDefault();
            if (cart is null) return false;

            var item = cart.Items.FirstOrDefault(i => i.Id == request.CartItemId);
            if (item is null) return false;

            cartItemRepository.Remove(item);
            await cartItemRepository.SaveChangesAsync();

            await cacheHelper.RemoveAsync($"cart:{request.UserId}");
            return true;
        }
    }
}


