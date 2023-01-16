namespace LaNacion.Application.UnitTests.Tests.Features.Phones.Queries
{
    public class GetPhoneByContactIdTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetPhoneByContactIdQueryTest()
        {
            //Arrange
            var contactId = 30;
            var handler = new GetPhoneByContactIdQueryHandler(_phoneRepository, _mapper);

            //Act
            var result = await handler.Handle(new GetPhoneByContactIdQuery() { ContactId = contactId }, CancellationToken.None);
            var phone = await _phoneRepository.GetByIdAsync(result.Data.Id);

            //Assert
            result.ShouldBeOfType<Response<PhoneDTO>>();
            phone.ContactId.ShouldBe(contactId);
        }
    }
}
