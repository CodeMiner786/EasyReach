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
            // EF Core SQL query-তে সরাসরি '==' ব্যবহার করা সবচেয়ে দ্রুত এবং নির্ভরযোগ্য
            var pages = await repository.FindAsync(p => p.Slug == request.Slug && p.IsPublished);
            var page = pages.FirstOrDefault();

            return page == null ? null : mapper.Map<PageDto>(page);
        }
    }
}

