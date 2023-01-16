namespace LaNacion.Application.UnitTests.Tests.Features.Phones.Commands
{
    public class CreatePhoneCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldCreatePhone()
        {

            //Arrange
            var createPhoneCommand = new CreatePhoneCommand()
            {
                ContactId = 19,
                PhoneNumber = "12345678",
                PhoneType = Domain.Enums.PhoneType.Work

            };

            var handler = new CreatePhoneCommandHandler(_phoneRepository, _mapper, _contactRepository);

            //Act
            var result = await handler.Handle(createPhoneCommand, CancellationToken.None);
            var createdPhone = await _phoneRepository.GetByIdAsync(result.Data);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            createdPhone.ContactId.ShouldBe(createPhoneCommand.ContactId);
            createdPhone.PhoneNumber.ShouldBe(createPhoneCommand.PhoneNumber);
            createdPhone.PhoneType.ShouldBe(createPhoneCommand.PhoneType);

        }
    }
}
