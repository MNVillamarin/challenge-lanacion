namespace LaNacion.Application.UnitTests.Tests.Features.Addresses.Queries
{
    public class GetAddressByIdQueryTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetAddressByIdQueryTest()
        {
            //Arrange
            var addressId = 43;
            var handler = new GetAddressByIdQueryHandler(_addressRepository, _mapper);

            //Act
            var result = await handler.Handle(new GetAddressByIdQuery() { Id = addressId }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Response<AddressDTO>>();
            result.Data.Id.ShouldBe(addressId);
        }
    }
}
