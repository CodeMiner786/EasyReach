using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    public class UpdatePageDtoValidator : AbstractValidator<UpdatePageDto>
    {
        public UpdatePageDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Page title is required.")
                .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Page slug is required.")
                .MaximumLength(150).WithMessage("Slug cannot exceed 150 characters.");
        }
    }
}
