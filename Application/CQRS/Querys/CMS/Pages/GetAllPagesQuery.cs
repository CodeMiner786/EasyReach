using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.CMS.Pages
{
    public record GetAllPagesQuery() : IRequest<List<PageDto>>;
    public record GetPageBySlugQuery(string Slug) : IRequest<PageDto?>;
}
