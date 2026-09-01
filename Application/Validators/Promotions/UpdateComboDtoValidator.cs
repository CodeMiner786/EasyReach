using FluentValidation;
using EasyReach_Application.DTOs.Promotions;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// UpdateComboDto validate korar rule.
    /// </summary>
    public class UpdateComboDtoValidator : AbstractValidator<UpdateComboDto>
    {
        public UpdateComboDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

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
