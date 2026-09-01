using FluentValidation;
using EasyReach_Application.DTOs.Promotions;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// CreateComboDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateComboDtoValidator : AbstractValidator<CreateComboDto>
    {
        public CreateComboDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ImageUrl).MaximumLength(200).When(x => x.ImageUrl != null);
            RuleFor(x => x.ComboPrice).GreaterThan(0);
            RuleFor(x => x.RegularPrice).GreaterThan(0);
            RuleFor(x => x.ComboPrice).LessThan(x => x.RegularPrice)
                .WithMessage("ComboPrice obossoi RegularPrice theke kom hote hobe.");
        }
    }
}
