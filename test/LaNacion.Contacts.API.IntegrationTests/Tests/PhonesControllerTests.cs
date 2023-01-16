namespace LaNacion.Contacts.API.IntegrationTests.Tests
{
    public class PhonesControllerTests : IClassFixture<ContactsApi<Program>>
    {
        private readonly HttpClient _client;
        private readonly ContactsApi<Program> _factory;

        public PhonesControllerTests(ContactsApi<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task GetPhoneById_Returns200OkResult_And_Return_Correct_Id()
        {
            // Act
            var response = await _client.GetAsync("api/Phones/10");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPhoneById_Returns404NotFound()
        {
            // Act
            var response = await _client.GetAsync("api/Phones/2000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetPhonesByContactId_Returns200OkResult()
        {
            // Act
            var response = await _client.GetAsync("api/Phones/GetPhoneByContactId/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task GetPhoneByContactId_Returns404NotFound()
        {
            // Act
            var response = await _client.GetAsync("api/Phones/GetPhoneByContactId/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreatePhone_Returns201Created()
        {
            // Arrange
            CreatePhoneCommand createPhone = new()
            {
                ContactId = 5,
                PhoneType = Domain.Enums.PhoneType.Work,
                PhoneNumber = "12345678"
            };

            var serializeCreatePhone = JsonConvert.SerializeObject(createPhone);
            var content = new StringContent(serializeCreatePhone, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Phones", content);


            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task CreatePhone_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            CreatePhoneCommand createPhone = new()
            {
                PhoneType = Domain.Enums.PhoneType.Work,
                PhoneNumber = ""
            };

            var serializeCreatePhone = JsonConvert.SerializeObject(createPhone);
            var content = new StringContent(serializeCreatePhone, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Phones", content);


            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdatePhone_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            UpdatePhoneCommand createAddress = new()
            {
                PhoneType = Domain.Enums.PhoneType.Work,
                PhoneNumber = "",
                Id = 1
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Phones/1", content);


            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdatePhone_Returns404NotFound_Id()
        {
            // Arrange
            UpdatePhoneCommand createPhone = new()
            {
                PhoneType = Domain.Enums.PhoneType.Work,
                PhoneNumber = "5555555",
                Id = 2000
            };

            var serializeCreatePhone = JsonConvert.SerializeObject(createPhone);
            var content = new StringContent(serializeCreatePhone, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Phones/2000", content);


            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task UpdatePhone_Returns200Ok()
        {
            // Arrange
            UpdatePhoneCommand createPhone = new()
            {
                PhoneType = Domain.Enums.PhoneType.Work,
                PhoneNumber = "5555555",
                Id = 5
            };

            var serializeCreatePhone = JsonConvert.SerializeObject(createPhone);
            var content = new StringContent(serializeCreatePhone, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Phones/5", content);


            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeletePhone_Returns200Ok()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Phones/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeletePhone_Returns404NotFound()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Phones/2000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

    }
}
