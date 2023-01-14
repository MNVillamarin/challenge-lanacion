using FluentValidation;

namespace LaNacion.Application.Features.Addresses.Commands.CreateAddressCommand
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(p => p.ContactId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

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
