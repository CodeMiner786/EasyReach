using FluentValidation;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// CreateDiscountDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateDiscountDtoValidator : AbstractValidator<CreateDiscountDto>
    {
        public CreateDiscountDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                .WithMessage("EndDate obossoi StartDate er por hote hobe.");
        }
    }
}
