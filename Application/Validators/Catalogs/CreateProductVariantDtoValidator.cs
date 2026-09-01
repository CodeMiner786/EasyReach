using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// CreateProductVariantDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateProductVariantDtoValidator : AbstractValidator<CreateProductVariantDto>
    {
        public CreateProductVariantDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.VariantName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(200);
            RuleFor(x => x.RegularPrice).GreaterThan(0);
            RuleFor(x => x.DiscountPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.WeightOrVolume).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Unit).IsInEnum();
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StockStatus).IsInEnum();
            RuleFor(x => x.DiscountPrice).LessThan(x => x.RegularPrice)
                .When(x => x.DiscountPrice.HasValue)
                .WithMessage("DiscountPrice obossoi RegularPrice theke kom hote hobe.");
        }
    }
}
