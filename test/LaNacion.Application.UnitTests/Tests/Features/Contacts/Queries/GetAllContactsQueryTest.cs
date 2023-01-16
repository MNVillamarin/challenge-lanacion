namespace LaNacion.Application.UnitTests.Tests.Features.Contacts.Queries
{
    public class GetAllContactsQueryTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldGetAllContacts()
        {

            //Arrange
            var getAllContactsQuery = new GetAllContactsQuery()
            {
                PageNumber = 1,
                PageSize = 25
            };
            var handler = new GetAllContactsHandler(_contactRepository, _mapper);

            //Act
            var result = await handler.Handle(getAllContactsQuery, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<PagedResponse<List<ContactDTO>>>();
            result.Data.Count.ShouldBe(25);
            result.PageSize.ShouldBe(25);

        }
    }
}
