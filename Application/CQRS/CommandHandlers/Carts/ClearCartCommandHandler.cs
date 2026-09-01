using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Carts
{
    public class ClearCartCommandHandler(
        ICartRepository cartRepository,
        ICacheHelper cacheHelper) : IRequestHandler<ClearCartCommand, bool>
    {
        public async Task<bool> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var cartList = await cartRepository.FindAsync(c => c.UserId == request.UserId);
            var cart = cartList.FirstOrDefault();
            if (cart is null) return false;

            cartRepository.Remove(cart);
            await cartRepository.SaveChangesAsync();

            await cacheHelper.RemoveAsync($"cart:{request.UserId}");
            return true;
        }
    }
}

