using FluentValidation;

namespace LaNacion.Application.Features.Contacts.Commands.UpdateContactCommand
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

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

        }

    }

}
