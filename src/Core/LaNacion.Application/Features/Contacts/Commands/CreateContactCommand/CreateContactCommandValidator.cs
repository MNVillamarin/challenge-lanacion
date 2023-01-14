using FluentValidation;
using LaNacion.Application.DTOs;

namespace LaNacion.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Company)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.ProfileImage)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(1000).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Invalid {PropertyName} address.")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Birthdate)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .LessThan(DateTime.Now.AddDays(1)).WithMessage("{PropertyName} must be less than today.");

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
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .IsInEnum().WithMessage("{PropertyName} only accepts the following values: {PropertyValue}.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(20).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");
        }
    }

    public class CreateAddressDTOValidator : AbstractValidator<CreateAddressDTO>
    {
        public CreateAddressDTOValidator()
        {
            RuleFor(p => p.Street)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(p => p.ZipCode)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");
        }
    }
}
