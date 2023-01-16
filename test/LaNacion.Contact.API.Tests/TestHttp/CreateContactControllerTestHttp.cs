using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace LaNacion.Contacts.API.Tests.TestHttp
{
    public class CreateContactControllerTestHttp : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;
        private readonly CreateContactCommand _command;

        public CreateContactControllerTestHttp(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _command = new CreateContactCommand
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Birthdate = new DateTime(1990, 01, 01),
                Address = new CreateAddressDTO
                {
                    City = "New York",
                    State = "NY",
                    Street = "Pepe",
                    ZipCode = "22"
                },
                Phones = new List<CreatePhoneDTO>
            {
                new CreatePhoneDTO { PhoneType = Domain.Enums.PhoneType.Work, PhoneNumber = "1234567890" },
                new CreatePhoneDTO { PhoneType = Domain.Enums.PhoneType.Personal, PhoneNumber = "0987654321" }
            }
            };
        }

        [Fact]
        public async Task CreateContact_ReturnsCreatedResult()
        {
            // Act
            var content = new StringContent(JsonConvert.SerializeObject(_command), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/contacts", content);
            var result = JsonConvert.DeserializeObject<Response<int>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("https://localhost/api/contacts/" + result.Data, response.Headers.Location.ToString());
            Assert.Equal(1, result.Data);
        }
    }
}
