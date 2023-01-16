namespace LaNacion.Application.UnitTests.Tests.Features.Contacts.Commands
{
    public class CreateContactCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldCreateContact()
        {

            //Arrange
            var createContactCommand = new CreateContactCommand()
            {
                Name = "Create Test Name",
                Company = "Create Test Company",
                ProfileImage = "CreateTestImage.jpg",
                Email = "CreateTest@test.com",
                Birthdate = DateTime.Now.AddDays(-10),
                Phones = new List<CreatePhoneDTO>
                {
                    new CreatePhoneDTO() { PhoneType = Domain.Enums.PhoneType.Personal, PhoneNumber = "87654321" },
                    new CreatePhoneDTO() { PhoneType = Domain.Enums.PhoneType.Work, PhoneNumber = "123456789" }
                },
                Address = new CreateAddressDTO()
                {
                    City = "Test City",
                    State = "Test State",
                    Street = "Test Street",
                    ZipCode = "Test Zip Code"
                }
            };

            var handler = new CreateContactCommandHandler(_contactRepository, _mapper);

            //Act
            var result = await handler.Handle(createContactCommand, CancellationToken.None);
            var createdContact = await _contactRepository.GetByIdAsync(result.Data);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            createdContact.Name.ShouldBe(createContactCommand.Name);
            createdContact.Company.ShouldBe(createContactCommand.Company);
            createdContact.ProfileImage.ShouldBe(createContactCommand.ProfileImage);
            createdContact.Email.ShouldBe(createContactCommand.Email);
            createdContact.Birthdate.ShouldBe(createContactCommand.Birthdate);
            createdContact.Phones.Count().ShouldBe(createContactCommand.Phones.Count());
            createdContact.Address.State.ShouldBe(createContactCommand.Address.State);
            createdContact.Address.City.ShouldBe(createContactCommand.Address.City);
            createdContact.Address.Street.ShouldBe(createContactCommand.Address.Street);
            createdContact.Address.ZipCode.ShouldBe(createContactCommand.Address.ZipCode);

        }
    }
}
