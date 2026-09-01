using EasyReach_Application.DTOs.LandingPages;
using EasyReach_Domain.Entities.LandingPages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyReach_Application.Validators.LandingPages
{
    // আপনি Command বা Create/Update DTO যেই ক্লাসটি ব্যবহার করবেন সেটি T-তে বসাবেন
    public class CreateLandingPageDtoValidator : AbstractValidator<CreateLandingPageDto>
    {
        private static readonly Regex SlugRegex = new(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", RegexOptions.Compiled);

        public CreateLandingPageDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);

            RuleFor(x => x.Slug)
                .NotEmpty()
                .MaximumLength(200)
                .Must(slug => string.IsNullOrEmpty(slug) || SlugRegex.IsMatch(slug))
                .WithMessage("Slug can only contain lowercase letters, numbers, and hyphens.");

            RuleFor(x => x.HeroTitle).NotEmpty().MaximumLength(250);
            RuleFor(x => x.HeroSubtitle).MaximumLength(500);
            RuleFor(x => x.HeroImageUrl).MaximumLength(500);
            RuleFor(x => x.CallToActionText).MaximumLength(100);
            RuleFor(x => x.CallToActionUrl).MaximumLength(500);
            RuleFor(x => x.MetaTitle).MaximumLength(150);
            RuleFor(x => x.MetaDescription).MaximumLength(500);
        }
    }
}
