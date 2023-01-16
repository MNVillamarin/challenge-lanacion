namespace LaNacion.Application.UnitTests.Tests.Features.Contacts.Queries
{
    public class GetContactByIdQueryTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetContactById()
        {

            //Arrange
            var expectedId = 10;
            var handler = new GetContactByIdQueryHandler(_contactRepository, _mapper);

            //Act
            var result = await handler.Handle(new GetContactByIdQuery() { Id = expectedId }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Response<ContactDTO>>();
            result.Data.Id.ShouldBe(expectedId);

        }
    }
}
