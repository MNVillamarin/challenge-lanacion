using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using LaNacion.Application.Features.Contacts.Commands.DeleteContactCommand;
using LaNacion.Application.Features.Contacts.Commands.UpdateContactCommand;
using LaNacion.Application.Features.Contacts.Queries.GetAllContacts;
using LaNacion.Application.Features.Contacts.Queries.GetContactById;
using LaNacion.Application.Features.Contacts.Queries.GetContactsByParameters;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contact.API.Controllers
{
    public class ContactController : BaseApiController
    {
        //GET api/Contact
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllContactsParameters parameters)
        {
            return Ok(await Mediator.Send(new GetAllContactsQuery
            {
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                Email = parameters.Email,
                PhoneNumber = parameters.PhoneNumber,
                City = parameters.City,
                State = parameters.State
            }));
        }
        //GET api/Contact/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetContactByIdQuery { Id = id }));
        }

        //POST api/Contact
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateContactCommand command)
        {
            var response = await Mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Contact/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateContactCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //Delete api/Contact/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(DeleteContactCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
