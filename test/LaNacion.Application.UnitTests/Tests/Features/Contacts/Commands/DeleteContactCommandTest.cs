namespace LaNacion.Application.UnitTests.Tests.Features.Contacts.Commands
{
    public class DeleteContactCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldDeleteContact()
        {

            //Arrange
            var contactToDeleteId = 1;
            var handler = new DeleteContactHandler(_contactRepository);

            //Act
            var result = await handler.Handle(new DeleteContactCommand() { Id = contactToDeleteId }, CancellationToken.None);
            var deletedContact = await _contactRepository.GetByIdAsync(contactToDeleteId);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            deletedContact.ShouldBeNull();

        }
    }
}
