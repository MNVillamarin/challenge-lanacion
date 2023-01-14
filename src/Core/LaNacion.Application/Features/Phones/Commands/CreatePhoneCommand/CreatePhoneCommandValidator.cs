using FluentValidation;

namespace LaNacion.Application.Features.Phones.Commands.CreatePhoneCommand
{
    public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(p => p.ContactId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

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
}
