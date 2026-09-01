using FluentValidation;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// UpdateDiscountDto validate korar rule.
    /// </summary>
    public class UpdateDiscountDtoValidator : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                .WithMessage("EndDate obossoi StartDate er por hote hobe.");
        }
    }
}
