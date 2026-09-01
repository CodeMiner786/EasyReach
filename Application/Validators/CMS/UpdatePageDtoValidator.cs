using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// UpdatePageDto validate korar rule.
    /// </summary>
    public class UpdatePageDtoValidator : AbstractValidator<UpdatePageDto>
    {
        public UpdatePageDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(2000);
        }
    }
}
