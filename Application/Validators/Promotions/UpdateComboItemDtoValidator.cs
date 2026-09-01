using FluentValidation;
using EasyReach_Application.DTOs.Promotions;

namespace EasyReach_Application.Validators.Promotions
{
    /// <summary>
    /// UpdateComboItemDto validate korar rule.
    /// </summary>
    public class UpdateComboItemDtoValidator : AbstractValidator<UpdateComboItemDto>
    {
        public UpdateComboItemDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ComboId).NotEmpty();
            RuleFor(x => x.ProductVariantId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}
