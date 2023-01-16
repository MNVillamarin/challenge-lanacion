namespace LaNacion.Application.UnitTests.Tests.Features.Phones.Commands
{
    public class DeletePhoneCommandTest : FeaturesBaseTest
    {

        [Fact]
        public async Task ShouldDeletePhone()
        {

            //Arrange
            var phoneToDeleteId = 2;
            var handler = new DeletePhoneCommandHandler(_phoneRepository);

            //Act
            var result = await handler.Handle(new DeletePhoneCommand() { Id = phoneToDeleteId }, CancellationToken.None);
            var deletedPhone = await _phoneRepository.GetByIdAsync(phoneToDeleteId);

            //Assert
            result.ShouldBeOfType<Response<int>>();
            deletedPhone.ShouldBeNull();

        }
    }
}
