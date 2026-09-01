using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// UpdateTestimonialDto validate korar rule.
    /// </summary>
    public class UpdateTestimonialDtoValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Occupation).MaximumLength(200).When(x => x.Occupation != null);
            RuleFor(x => x.ImageUrl).MaximumLength(200).When(x => x.ImageUrl != null);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Rating).InclusiveBetween(1, 5)
                .WithMessage("Rating 1 theke 5 er moddhe hote hobe.");
        }
    }
}
