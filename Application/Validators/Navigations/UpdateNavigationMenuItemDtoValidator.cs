using FluentValidation;
using EasyReach_Application.DTOs.Navigations;

namespace EasyReach_Application.Validators.Navigations
{
    /// <summary>
    /// UpdateNavigationMenuItemDto validate korar rule.
    /// </summary>
    public class UpdateNavigationMenuItemDtoValidator : AbstractValidator<UpdateNavigationMenuItemDto>
    {
        public UpdateNavigationMenuItemDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Label).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IconClass).MaximumLength(200).When(x => x.IconClass != null);
            RuleFor(x => x.Route).MaximumLength(200).When(x => x.Route != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
