namespace LaNacion.Application.UnitTests.Tests.Features.Addresses.Queries
{
    public class GetAddressByContactIdQueryTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetAddressByContactIdTest()
        {
            //Arrange
            var contactId = 30;
            var handler = new GetAddressByContactIdQueryHandler(_addressRepository, _mapper);

            //Act
            var result = await handler.Handle(new GetAddressByContactIdQuery() { ContactId = contactId }, CancellationToken.None);
            var address = await _addressRepository.GetByIdAsync(result.Data.Id);

            //Assert
            result.ShouldBeOfType<Response<AddressDTO>>();
            address.ContactId.ShouldBe(contactId);
        }
    }
}
