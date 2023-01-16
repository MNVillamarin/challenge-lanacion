namespace LaNacion.Application.UnitTests.Tests.Features.Addresses.Commands
{
    public class CreateAddressCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldCreateAddress()
        {

            //Arrange
            var createAddressCommand = new CreateAddressCommand()
            {
                ContactId = 17,
                City = "Test City",
                State = "Test State",
                Street = "Test Street",
                ZipCode = "Test Zip Code"

            };

            var handler = new CreateAddressCommandHandler(_addressRepository, _contactRepository, _mapper);

            //Act
            var result = await handler.Handle(createAddressCommand, CancellationToken.None);
            var createdAddress = await _addressRepository.GetByIdAsync(result.Data);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            createdAddress.ContactId.ShouldBe(createAddressCommand.ContactId);
            createdAddress.State.ShouldBe(createAddressCommand.State);
            createdAddress.City.ShouldBe(createAddressCommand.City);
            createdAddress.Street.ShouldBe(createAddressCommand.Street);
            createdAddress.ZipCode.ShouldBe(createAddressCommand.ZipCode);

        }
    }
}
