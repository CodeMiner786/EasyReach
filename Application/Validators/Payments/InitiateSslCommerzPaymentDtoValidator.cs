using EasyReach_Application.DTOs.Payments;
using FluentValidation;

namespace EasyReach_Application.Validators.Payments
{
    public class InitiateSslCommerzPaymentDtoValidator : AbstractValidator<InitiateSslCommerzPaymentDto>
    {
        public InitiateSslCommerzPaymentDtoValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CustomerEmail).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.CustomerPhone).NotEmpty().MaximumLength(20);
            RuleFor(x => x.CustomerAddress).NotEmpty().MaximumLength(250);
        }
    }
}
