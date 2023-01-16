using Application.Exceptions;
using FluentValidation.Results;

namespace LaNacion.Application.UnitTests.Tests.Exceptions
{
    public class ValidationExceptionTest
    {

        [Fact]
        public void ShouldValidationExceptionDefaultConstructorMessage()
        {

            //Arrange
            var ex = new ValidationException();

            //Assert
            ex.Message.ShouldBe("One or more validation errors have occurred.");

        }


        [Fact]
        public void ShouldValidationExceptionListErrorsConstructor()
        {

            //Arrange
            var listErrors = new List<ValidationFailure> { new("Email", "Invalid Email Address.") };

            var ex = new ValidationException(listErrors);

            //Assert
            ex.Message.ShouldBe("One or more validation errors have occurred.");
            ex.Errors.FirstOrDefault().ShouldBe("Invalid Email Address.");

        }
    }
}
