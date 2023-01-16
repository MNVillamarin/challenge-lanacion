namespace LaNacion.Application.UnitTests.Tests.Features.Addresses.Commands
{
    public class UpdateAddressCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldUpdateAddress()
        {

            //Arrange
            var updateAddressCommand = new UpdateAddressCommand()
            {
                Id = 1,
                City = "Test City",
                State = "Test State",
                Street = "Test Street",
                ZipCode = "Test Zip Code"

            };
            var handler = new UpdateAddressCommandHandler(_addressRepository, _mapper);

            //Act
            var result = await handler.Handle(updateAddressCommand, CancellationToken.None);
            var updatedAddress = await _addressRepository.GetByIdAsync(result.Data);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            updatedAddress.Id.ShouldBe(updateAddressCommand.Id);
            updatedAddress.State.ShouldBe(updateAddressCommand.State);
            updatedAddress.City.ShouldBe(updateAddressCommand.City);
            updatedAddress.Street.ShouldBe(updateAddressCommand.Street);
            updatedAddress.ZipCode.ShouldBe(updateAddressCommand.ZipCode);

        }
    }
}
