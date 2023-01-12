using FluentValidation;
using LaNacion.Application.DTOs.Contacts;

namespace LaNacion.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name cannot be null.")
                .MaximumLength(256).WithMessage("Name cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Company)
                .NotEmpty().WithMessage("Company cannot be empty.")
                .NotNull().WithMessage("Company cannot be null.")
                .MaximumLength(256).WithMessage("Company cannot exceed {MaxLength} characters.");

            RuleFor(p => p.ProfileImage)
                .NotEmpty().WithMessage("ProfileImage cannot be empty.")
                .NotNull().WithMessage("ProfileImage cannot be null.")
                .MaximumLength(1000).WithMessage("ProfileImage cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Invalid email address.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .NotNull().WithMessage("Email cannot be null.")
                .MaximumLength(256).WithMessage("Email cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Birthdate)
                .NotEmpty().WithMessage("Birthdate cannot be empty.")
                .NotNull().WithMessage("Birthdate cannot be null.");

            When(p => p.Phones != null, () =>
            {
                RuleForEach(p => p.Phones)
                .SetValidator(new CreatePhoneDTOValidator());
            });

            When(p => p.Address != null, () =>
            {
                RuleFor(p => p.Address)
                .SetValidator(new CreateAddressDTOValidator());
            });
        }
    }

    public class CreatePhoneDTOValidator : AbstractValidator<CreatePhoneDTO>
    {
        public CreatePhoneDTOValidator()
        {
            RuleFor(p => p.PhoneType)
                .NotEmpty().WithMessage("PhoneType cannot be empty.")
                .NotNull().WithMessage("PhoneType cannot be null.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty.")
                .NotNull().WithMessage("PhoneNumber cannot be null."); ;
        }
    }

    public class CreateAddressDTOValidator : AbstractValidator<CreateAddressDTO>
    {
        public CreateAddressDTOValidator()
        {
            RuleFor(p => p.Street)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.City)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.State)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.ZipCode)
                .NotEmpty()
                .NotNull();
        }
    }
}
