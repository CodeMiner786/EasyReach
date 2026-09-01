using AutoMapper;
using EasyReach_Application.CQRS.Querys.Payments;
using EasyReach_Application.DTOs.Payments;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Payments
{
    public class GetUserPaymentHistoryQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        : IRequestHandler<GetUserPaymentHistoryQuery, PagedResult<PaymentResponseDto>>
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResult<PaymentResponseDto>> Handle(GetUserPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            // 🚀 Navigation property (Order.UserId) ব্যবহার করে ফিল্টার করা হচ্ছে
            var pagedPayments = await _paymentRepository.GetPagedAsync(
                request.PaginationParams,
                predicate: p => p.Order != null && p.Order.UserId == request.UserId,
                orderBy: q => q.OrderByDescending(p => p.CreatedAt)
            );

            var mappedItems = _mapper.Map<List<PaymentResponseDto>>(pagedPayments.Items);

            return new PagedResult<PaymentResponseDto>(
                mappedItems,
                pagedPayments.TotalCount,
                pagedPayments.PageNumber,
                pagedPayments.PageSize
            );
        }
    }
}

