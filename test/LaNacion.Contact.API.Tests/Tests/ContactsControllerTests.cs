
namespace LaNacion.Contacts.API.Tests.Tests
{
    public class ContactsControllerTests
    {

        [Fact]
        public async Task GetContactById_Returns200OkResult_And_Return_Id_1()
        {
            // Arrange
            var id = 1;
            var helper = new ContextHelper();
            var contactRepository = helper.GetInMemoryContactRepository();
            var mapper = helper.GetMapper();

            var handler = new GetContactByIdQueryHandler(contactRepository, mapper);
            var mediator = new Mock<IMediator>();
            mediator
                .Setup(x => x.Send(It.IsAny<GetContactByIdQuery>(), default(CancellationToken)))
                .ReturnsAsync(await handler.Handle(new GetContactByIdQuery() { Id = id }, default(CancellationToken)));

            var controller = new ContactsController(mediator.Object);


            // Act
            var result = await controller.GetContactById(id);




            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Response<ContactDTO>)((OkObjectResult)result).Value).Data.Id);
        }


        [Fact]
        public async Task GetContactById_ReturnsKeyNotFoundException()
        {
            // Arrange
            Exception expectedException = null;
            try
            {

                var id = 0;
                var helper = new ContextHelper();
                var contactRepository = helper.GetInMemoryContactRepository();
                var mapper = helper.GetMapper();

                var handler = new GetContactByIdQueryHandler(contactRepository, mapper);
                var mediator = new Mock<IMediator>();
                mediator
                    .Setup(x => x.Send(It.IsAny<GetContactByIdQuery>(), default(CancellationToken)))
                    .ReturnsAsync(await handler.Handle(new GetContactByIdQuery() { Id = id }, default(CancellationToken)));

                var controller = new ContactsController(mediator.Object);


                // Act

                await controller.GetContactById(id);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.NotNull(expectedException);
            Assert.IsType<KeyNotFoundException>(expectedException);

        }


        [Fact]
        public async Task GetAllContacts_Returns200OkResult_And_Return_Default_PageNumber_And_PageSize()
        {
            // Arrange
            var defaultPageNumber = 1;
            var defaultPageSize = 10;
            var helper = new ContextHelper();
            var contactRepository = helper.GetInMemoryContactRepository();
            var mapper = helper.GetMapper();

            var handler = new GetAllContactsHandler(contactRepository, mapper);
            var mediator = new Mock<IMediator>();
            mediator
                .Setup(x => x.Send(It.IsAny<GetAllContactsQuery>(), default(CancellationToken)))
                .ReturnsAsync(await handler.Handle(new GetAllContactsQuery()
                {
                    PageSize = defaultPageSize,
                    PageNumber = defaultPageNumber,

                }, default(CancellationToken)));

            var controller = new ContactsController(mediator.Object);

            var getAllContactsParameters = new GetAllContactsParameters();

            // Act
            var result = await controller.GetAllContacts(getAllContactsParameters);


            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPageNumber, ((PagedResponse<List<ContactDTO>>)((OkObjectResult)result).Value).PageNumber);
            Assert.Equal(defaultPageSize, ((PagedResponse<List<ContactDTO>>)((OkObjectResult)result).Value).PageSize);
        }


        //[Fact]
        //public async Task CreateContact_Returns201Result_And_Return_Id()
        //{
        //    // Arrange
        //    var idExpected = 51;
        //    var testContact = new CreateContactCommand()
        //    {
        //        Name = "Test",
        //        Company = "Test",
        //        ProfileImage = "Test",
        //        Email = "Test@test.com",
        //        Birthdate = DateTime.Now.AddDays(-1),
        //    };
        //    var helper = new ContextHelper();
        //    var contactRepository = helper.GetInMemoryContactRepository();
        //    var phoneRepository = helper.GetInMemoryPhoneRepository();
        //    var mapper = helper.GetMapper();

        //    var handler = new CreateContactCommandHandler(contactRepository, mapper);
        //    var mediator = new Mock<IMediator>();
        //    mediator
        //        .Setup(x => x.Send(It.IsAny<CreateContactCommand>(), default(CancellationToken)))
        //        .ReturnsAsync(await handler.Handle(new CreateContactCommand { Email = "Test", Name = "Test" }, default(CancellationToken)));

        //    var controller = new ContactsController(mediator.Object);


        //    // Act
        //    var result = await controller.CreateContact(testContact);


        //    // Assert
        //    Assert.IsType<CreatedResult>(result);
        //    Assert.Equal(idExpected, ((Response<int>)((OkObjectResult)result).Value).Data);
        //}

    }
}