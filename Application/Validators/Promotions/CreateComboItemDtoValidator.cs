using FluentValidation;
using EasyReach_Application.DTOs.Promotions;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// CreateComboItemDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateComboItemDtoValidator : AbstractValidator<CreateComboItemDto>
    {
        public CreateComboItemDtoValidator()
        {
            RuleFor(x => x.ComboId).NotEmpty();
            RuleFor(x => x.ProductVariantId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}
