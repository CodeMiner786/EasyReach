using FluentValidation;
using EasyReach_Application.DTOs.Orders;

namespace EasyReach_Application.Validators.Orders
{
    /// <summary>
    /// UpdateShippingAddressDto validate korar rule.
    /// </summary>
    public class UpdateShippingAddressValidator : AbstractValidator<UpdateShippingAddressDto>
    {
        public UpdateShippingAddressValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Shipping address ID is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name is required.")
                .MaximumLength(150)
                .WithMessage("Full name cannot exceed 150 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^01[3-9]\d{8}$")
                .WithMessage("Please enter a valid Bangladesh mobile number.");

            RuleFor(x => x.AddressLine)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(500)
                .WithMessage("Address cannot exceed 500 characters.");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(100)
                .WithMessage("City cannot exceed 100 characters.");

            RuleFor(x => x.District)
                .NotEmpty()
                .WithMessage("District is required.")
                .MaximumLength(100)
                .WithMessage("District cannot exceed 100 characters.");

            RuleFor(x => x.PostalCode)
                .MaximumLength(20)
                .WithMessage("Postal code cannot exceed 20 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.PostalCode));
        }
    }
}
