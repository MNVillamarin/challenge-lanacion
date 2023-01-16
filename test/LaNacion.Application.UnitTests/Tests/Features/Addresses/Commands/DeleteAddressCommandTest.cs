namespace LaNacion.Application.UnitTests.Tests.Features.Addresses.Commands
{
    public class DeleteAddressCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldDeleteAddress()
        {

            //Arrange
            var addressToDeleteId = 25;
            var handler = new DeleteAddressCommandHandler(_addressRepository);

            //Act
            var result = await handler.Handle(new DeleteAddressCommand() { Id = addressToDeleteId }, CancellationToken.None);
            var deletedAddress = await _addressRepository.GetByIdAsync(addressToDeleteId);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            deletedAddress.ShouldBeNull();

        }
    }
}
