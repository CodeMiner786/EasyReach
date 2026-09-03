using AutoMapper;
using EasyReach_Application.CQRS.Commands.CMS.Pages;
using EasyReach_Application.CQRS.Querys.CMS.Pages;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.CMS.Pages
{
    public class CreatePageCommandHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<CreatePageCommand, Guid>
    {
        public async Task<Guid> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Page>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            if (request.Dto.BannerIds?.Count > 0)
            {
                entity.PageBanners = [.. request.Dto.BannerIds.Select((bannerId, index) => new PageBanner
                {
                    Id = Guid.NewGuid(),
                    PageId = entity.Id,
                    BannerId = bannerId,
                    DisplayOrder = index
                })];
            }

            if (request.Dto.Products?.Count > 0)
            {
                entity.PageProducts = [.. request.Dto.Products.Select(p => new PageProduct
                {
                    Id = Guid.NewGuid(),
                    PageId = entity.Id,
                    ProductId = p.ProductId,
                    DisplayOrder = p.DisplayOrder,
                    SectionTitle = p.SectionTitle
                })];
            }

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return entity.Id;
        }
    }

    public class UpdatePageCommandHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<UpdatePageCommand, bool>
    {
        public async Task<bool> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Page not found.");

            mapper.Map(request.Dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            entity.PageBanners.Clear();
            if (request.Dto.BannerIds?.Count > 0)
            {
                foreach (var (bannerId, index) in request.Dto.BannerIds.Select((id, idx) => (id, idx)))
                {
                    entity.PageBanners.Add(new PageBanner
                    {
                        Id = Guid.NewGuid(),
                        PageId = entity.Id,
                        BannerId = bannerId,
                        DisplayOrder = index
                    });
                }
            }

            entity.PageProducts.Clear();
            if (request.Dto.Products?.Count > 0)
            {
                foreach (var p in request.Dto.Products)
                {
                    entity.PageProducts.Add(new PageProduct
                    {
                        Id = Guid.NewGuid(),
                        PageId = entity.Id,
                        ProductId = p.ProductId,
                        DisplayOrder = p.DisplayOrder,
                        SectionTitle = p.SectionTitle
                    });
                }
            }

            repository.Update(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }

    public class GetAllPagesQueryHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<GetAllPagesQuery, List<PageDto>>
    {
        public async Task<List<PageDto>> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
        {
            // সাধারণ GetAllAsync() এর বদলে ব্যানার ও প্রোডাক্টসহ ডিটেইলস আনার জন্য GetAllWithDetailsAsync() ব্যবহার করা হলো
            var list = await repository.GetAllWithDetailsAsync();
            return mapper.Map<List<PageDto>>(list);
        }
    }
}

