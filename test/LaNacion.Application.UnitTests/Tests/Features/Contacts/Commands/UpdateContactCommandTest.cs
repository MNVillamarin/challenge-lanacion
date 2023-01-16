namespace LaNacion.Application.UnitTests.Tests.Features.Contacts.Commands
{
    public class UpdateContactCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldUpdateContact()
        {

            //Arrange
            var updateContactCommand = new UpdateContactCommand()
            {
                Id = 11,
                Name = "Update Test Name",
                Company = "Test Company",
                ProfileImage = "TestImage.jpg",
                Email = "UpdateTest@test.com",
                Birthdate = DateTime.Now.AddDays(-10)
            };
            var handler = new UpdateContactCommandHandler(_contactRepository, _mapper);

            //Act
            var result = await handler.Handle(updateContactCommand, CancellationToken.None);
            var updatedContact = await _contactRepository.GetByIdAsync(updateContactCommand.Id);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            updatedContact.Name.ShouldBe(updateContactCommand.Name);
            updatedContact.Company.ShouldBe(updateContactCommand.Company);
            updatedContact.ProfileImage.ShouldBe(updateContactCommand.ProfileImage);
            updatedContact.Email.ShouldBe(updateContactCommand.Email);
            updatedContact.Birthdate.ShouldBe(updateContactCommand.Birthdate);

        }
    }
}
