namespace LaNacion.Application.UnitTests.Tests.Features.Phones.Commands
{
    public class UpdatePhoneCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldUpdatePhone()
        {

            //Arrange
            var updatePhoneCommand = new UpdatePhoneCommand()
            {
                Id = 3,
                PhoneType = Domain.Enums.PhoneType.Personal,
                PhoneNumber = "12345678"
            };
            var handler = new UpdatePhoneCommandHandler(_phoneRepository, _mapper);

            //Act
            var result = await handler.Handle(updatePhoneCommand, CancellationToken.None);
            var updatedPhone = await _phoneRepository.GetByIdAsync(result.Data);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            updatedPhone.Id.ShouldBe(updatePhoneCommand.Id);
            updatedPhone.PhoneType.ShouldBe(updatePhoneCommand.PhoneType);
            updatedPhone.PhoneNumber.ShouldBe(updatePhoneCommand.PhoneNumber);

        }
    }
}
