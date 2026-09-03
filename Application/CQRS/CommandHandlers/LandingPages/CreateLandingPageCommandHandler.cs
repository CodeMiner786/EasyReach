using EasyReach_Application.CQRS.Commands.LandingPages;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.LandingPages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.LandingPages
{
    public class CreateLandingPageCommandHandler(
        ILandingPageRepository repository,
        ICacheHelper cacheHelper) : IRequestHandler<CreateLandingPageCommand, Guid>
    {
        public async Task<Guid> Handle(CreateLandingPageCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = new LandingPage
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Slug = dto.Slug,
                HeroTitle = dto.HeroTitle,
                HeroSubtitle = dto.HeroSubtitle,
                HeroImageUrl = dto.HeroImageUrl,
                OfferPrice = dto.OfferPrice,
                ShowDirectCheckoutForm = dto.ShowDirectCheckoutForm,
                ShowWhatsAppButton = dto.ShowWhatsAppButton,
                CallToActionText = dto.CallToActionText,
                CallToActionUrl = dto.CallToActionUrl,
                MetaTitle = dto.MetaTitle,
                MetaDescription = dto.MetaDescription,
                IsPublished = dto.IsPublished,
                CreatedAt = DateTime.UtcNow
            };

            if (dto.ProductId != Guid.Empty)
            {
                var landingPageProduct = new LandingPageProduct
                {
                    Id = Guid.NewGuid(),
                    LandingPageId = entity.Id,
                    ProductId = dto.ProductId,
                    CustomOfferPrice = dto.OfferPrice,
                    DisplayOrder = 1
                };

                entity.LandingPageProducts = [landingPageProduct];
            }

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("landingpages:published");
            return entity.Id;
        }
    }
}

