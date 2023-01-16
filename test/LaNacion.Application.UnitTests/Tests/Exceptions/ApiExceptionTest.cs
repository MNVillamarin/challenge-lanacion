using LaNacion.Application.Exceptions;

namespace LaNacion.Application.UnitTests.Tests.Exceptions
{
    public class ApiExceptionTest
    {
        [Fact]
        public void ShouldApiExceptionDefaultConstructorMessage()
        {

            //Arrange
            var ex = new ApiException("Error Test.");

            //Assert
            ex.Message.ShouldBe("Error Test.");

        }
    }
}
