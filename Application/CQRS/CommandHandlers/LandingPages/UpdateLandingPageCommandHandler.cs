using AutoMapper;
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
    public class UpdateLandingPageCommandHandler(
        ILandingPageRepository repository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<UpdateLandingPageCommand, bool>
    {
        public async Task<bool> Handle(UpdateLandingPageCommand request, CancellationToken cancellationToken)
        {
            var page = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Landing page not found.");

            string oldSlug = page.Slug;
            mapper.Map(request.Dto, page);
            page.UpdatedAt = DateTime.UtcNow;

            repository.Update(page);
            await repository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("landingpages:published");
            await cacheHelper.RemoveAsync($"landingpages:slug:{oldSlug.ToLower()}");
            await cacheHelper.RemoveAsync($"landingpages:slug:{page.Slug.ToLower()}");

            return true;
        }
    }
}
