namespace LaNacion.Contacts.API.IntegrationTests.Tests
{
    public class AddressesControllerTests : IClassFixture<ContactsApi<Program>>
    {
        private readonly HttpClient _client;
        private readonly ContactsApi<Program> _factory;

        public AddressesControllerTests(ContactsApi<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task GetAddressById_Returns200OkResult_And_Return_Correct_Id()
        {
            // Act
            var response = await _client.GetAsync("api/Addresses/10");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAddressById_Returns404NotFound()
        {
            // Act
            var response = await _client.GetAsync("api/Addresses/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAddressByContactId_Returns200OkResult()
        {
            // Act
            var response = await _client.GetAsync("api/Addresses/GetAddressByContactId/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task GetAddressByContactId_Returns404NotFound()
        {
            // Act
            var response = await _client.GetAsync("api/Addresses/GetAddressByContactId/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateAddress_Returns201Created()
        {
            // Arrange
            CreateAddressCommand createAddress = new()
            {
                Street = "Test",
                State = "Test",
                City = "Test",
                ZipCode = "1234",
                ContactId = 1
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Addresses", content);


            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task CreateAddress_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            CreateAddressCommand createAddress = new()
            {
                Street = "Test",
                State = "Test",
                City = "",
                ZipCode = "1234",
                ContactId = 1
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Addresses", content);


            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateAddress_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            UpdateAddressCommand createAddress = new()
            {
                Street = "Test",
                State = "Test",
                City = "",
                ZipCode = "1234",
                Id = 1
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Addresses/1", content);


            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateAddress_Returns404NotFound_Id()
        {
            // Arrange
            UpdateAddressCommand createAddress = new()
            {
                Street = "Test",
                State = "Test",
                City = "Test",
                ZipCode = "1234",
                Id = 1000
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Addresses/1000", content);


            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task UpdateAddress_Returns200Ok()
        {
            // Arrange
            UpdateAddressCommand createAddress = new()
            {
                Street = "Test",
                State = "Test",
                City = "Test",
                ZipCode = "1234",
                Id = 1
            };

            var serializeCreateAddress = JsonConvert.SerializeObject(createAddress);
            var content = new StringContent(serializeCreateAddress, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Addresses/1", content);


            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeleteAddress_Returns200Ok()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Addresses/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeleteAddress_Returns404NotFound()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Addresses/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

    }
}
