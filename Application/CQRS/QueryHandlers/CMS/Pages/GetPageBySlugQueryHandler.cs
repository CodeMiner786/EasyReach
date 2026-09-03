using AutoMapper;
using EasyReach_Application.CQRS.Querys.CMS.Pages;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.CMS.Pages
{
    public class GetPageBySlugQueryHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<GetPageBySlugQuery, PageDto?>
    {
        public async Task<PageDto?> Handle(GetPageBySlugQuery request, CancellationToken cancellationToken)
        {
            // রিলেটেড ব্যানার ও প্রোডাক্টসহ পেজ ফেচ করার কাস্টম রিপোজিটরি মেথড
            var page = await repository.GetPageWithDetailsBySlugAsync(request.Slug);

            return page == null ? null : mapper.Map<PageDto>(page);
        }
    }
}
