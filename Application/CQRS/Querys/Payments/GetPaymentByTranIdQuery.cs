using EasyReach_Application.DTOs.Payments;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.Querys.Payments
{
    public record GetPaymentByTranIdQuery(string TranId) : IRequest<PaymentResponseDto?>;
    public class GetUserPaymentHistoryQuery : IRequest<PagedResult<PaymentResponseDto>>
    {
        public Guid UserId { get; set; }
        public PaginationParams PaginationParams { get; set; } = new();
    }
}
