using EasyReach_Application.DTOs.Catalogs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Validators.Catalogs
{
    public class CreateProductVariantDtoValidator : AbstractValidator<CreateProductVariantDto>
    {
        public CreateProductVariantDtoValidator()
        {

            RuleFor(x => x.VariantName)
                .NotEmpty().WithMessage("Variant name is required.")
                .MaximumLength(200);

            RuleFor(x => x.SKU)
                .NotEmpty().WithMessage("SKU is required.")
                .MaximumLength(200);

            RuleFor(x => x.RegularPrice)
                .GreaterThan(0).WithMessage("Regular price must be greater than 0.");

            RuleFor(x => x.DiscountPrice)
                .GreaterThanOrEqualTo(0)
                .LessThan(x => x.RegularPrice)
                .When(x => x.DiscountPrice.HasValue && x.DiscountPrice > 0)
                .WithMessage("DiscountPrice must be less than RegularPrice.");

            RuleFor(x => x.WeightOrVolume).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Unit).IsInEnum();
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StockStatus).IsInEnum();
        }
    }
}
