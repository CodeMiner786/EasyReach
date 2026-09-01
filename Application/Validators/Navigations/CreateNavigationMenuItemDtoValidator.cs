using FluentValidation;
using EasyReach_Application.DTOs.Navigations;

namespace EasyReach_Application.Validators.Navigations
{
    /// <summary>
    /// CreateNavigationMenuItemDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateNavigationMenuItemDtoValidator : AbstractValidator<CreateNavigationMenuItemDto>
    {
        public CreateNavigationMenuItemDtoValidator()
        {
            RuleFor(x => x.Label).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IconClass).MaximumLength(200).When(x => x.IconClass != null);
            RuleFor(x => x.Route).MaximumLength(200).When(x => x.Route != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
