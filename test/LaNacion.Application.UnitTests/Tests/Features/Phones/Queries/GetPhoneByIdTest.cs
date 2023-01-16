
namespace LaNacion.Application.UnitTests.Tests.Features.Phones.Queries
{
    public class GetPhoneByIdTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetPhoneByIdQueryTest()
        {
            //Arrange
            var phoneId = 47;
            var handler = new GetPhoneByIdQueryHandler(_phoneRepository, _mapper);

            //Act
            var result = await handler.Handle(new GetPhoneByIdQuery() { Id = phoneId }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Response<PhoneDTO>>();
            result.Data.Id.ShouldBe(phoneId);
        }
    }
}
