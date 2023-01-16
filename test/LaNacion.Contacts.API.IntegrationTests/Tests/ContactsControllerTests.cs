namespace LaNacion.Contacts.API.IntegrationTests.Tests
{
    public class ContactsControllerTests : IClassFixture<ContactsApi<Program>>
    {
        private readonly HttpClient _client;
        private readonly ContactsApi<Program> _factory;

        public ContactsControllerTests(ContactsApi<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task GetContactById_Returns200OkResult_And_Return_Correct_Id()
        {
            // Act
            var response = await _client.GetAsync("api/Contacts/5");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetContactById_Returns404NotFound()
        {
            // Act
            var response = await _client.GetAsync("api/Contacts/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAllContacts_Returns200OkResult_And_Paged_Default_Correct()
        {
            // Act
            var result = await _client.GetAsync("/api/Contacts");
            var content = await result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<PagedResponse<List<ContactDTO>>>(content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(10, contacts.PageSize);

        }

        [Fact]
        public async Task GetAllContacts_Returns200OkResult_And_Paged_25_Correct()
        {
            // Act
            var result = await _client.GetAsync("/api/Contacts?PageSize=25");
            var content = await result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<PagedResponse<List<ContactDTO>>>(content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(25, contacts.PageSize);
        }

        [Fact]
        public async Task CreateContact_Returns201Created()
        {
            // Arrange
            CreateContactCommand createContact = new()
            {
                Name = "Test",
                Company = "Test",
                ProfileImage = "Test",
                Email = "Test@test.com",
                Birthdate = DateTime.Now.AddDays(-1),
            };

            var serializeCreateContact = JsonConvert.SerializeObject(createContact);
            var content = new StringContent(serializeCreateContact, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Contacts", content);


            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task CreateContact_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            CreateContactCommand createContact = new()
            {
                Name = "Test",
                Company = "Test",
                ProfileImage = "Test",
                Email = "Test",
                Birthdate = DateTime.Now.AddDays(-1),
            };

            var serializeCreateContact = JsonConvert.SerializeObject(createContact);
            var content = new StringContent(serializeCreateContact, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PostAsync("/api/Contacts", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateContact_Returns400BadRequest_Validation_Errors()
        {
            // Arrange
            UpdateContactCommand createContact = new()
            {
                Id = 1,
                Name = "Test",
                Company = "Test",
                ProfileImage = "Test",
                Email = "Test",
                Birthdate = DateTime.Now.AddDays(-1),
            };

            var serializeCreateContact = JsonConvert.SerializeObject(createContact);
            var content = new StringContent(serializeCreateContact, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Contacts/1", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateContact_Returns400BadRequest_When_Diferents_Id()
        {
            // Arrange
            UpdateContactCommand createContact = new()
            {
                Id = 1,
                Name = "Test",
                Company = "Test",
                ProfileImage = "Test",
                Email = "Test",
                Birthdate = DateTime.Now.AddDays(-1),
            };

            var serializeCreateContact = JsonConvert.SerializeObject(createContact);
            var content = new StringContent(serializeCreateContact, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Contacts/2", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateContact_Returns200Ok()
        {
            // Arrange
            UpdateContactCommand createContact = new()
            {
                Id = 5,
                Name = "Test",
                Company = "Test",
                ProfileImage = "Test",
                Email = "Test@test.com",
                Birthdate = DateTime.Now.AddDays(-1),
            };


            var serializeCreateContact = JsonConvert.SerializeObject(createContact);
            var content = new StringContent(serializeCreateContact, Encoding.UTF8, "application/json");

            // Act
            var result = await _client.PutAsync("/api/Contacts/5", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeleteContact_Returns200Ok()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Contacts/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeleteContact_Returns404NotFound()
        {
            // Act
            var result = await _client.DeleteAsync("/api/Contacts/1000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

    }


}
