using EasyReach_Application.CQRS.Commands.LandingPages;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.IRedis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.LandingPages
{
    public class DeleteLandingPageCommandHandler(
         ILandingPageRepository repository,
         ICacheHelper cacheHelper) : IRequestHandler<DeleteLandingPageCommand, bool>
    {
        public async Task<bool> Handle(DeleteLandingPageCommand request, CancellationToken cancellationToken)
        {
            var page = await repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Landing page not found.");

            repository.Remove(page);
            await repository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("landingpages:published");
            await cacheHelper.RemoveAsync($"landingpages:slug:{page.Slug.ToLower()}");

            return true;
        }
    }
}

