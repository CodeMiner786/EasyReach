using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// UpdateFaqItemDto validate korar rule.
    /// </summary>
    public class UpdateFaqItemDtoValidator : AbstractValidator<UpdateFaqItemDto>
    {
        public UpdateFaqItemDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Question).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.Answer).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
