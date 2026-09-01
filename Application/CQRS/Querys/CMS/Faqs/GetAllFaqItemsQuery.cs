using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.CMS.Faqs
{
    public record GetAllFaqItemsQuery() : IRequest<List<FaqItemDto>>;
    public record GetFaqItemByIdQuery(Guid Id) : IRequest<FaqItemDto?>;
}
