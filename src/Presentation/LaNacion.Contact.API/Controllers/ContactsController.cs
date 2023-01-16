using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using LaNacion.Application.Features.Contacts.Commands.DeleteContactCommand;
using LaNacion.Application.Features.Contacts.Commands.UpdateContactCommand;
using LaNacion.Application.Features.Contacts.Queries.GetAllContacts;
using LaNacion.Application.Features.Contacts.Queries.GetContactById;
using LaNacion.Application.Features.Contacts.Queries.GetContactsByParameters;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contacts.API.Controllers
{
    public class ContactsController : BaseApiController
    {
        public ContactsController(IMediator mediator) : base(mediator)
        {
        }

        //GET api/Contact
        [HttpGet()]
        public async Task<IActionResult> GetAllContacts([FromQuery] GetAllContactsParameters parameters)
        {
            return Ok(await _mediator.Send(new GetAllContactsQuery
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
        public async Task<IActionResult> GetContactById(int id)
        {
            return Ok(await _mediator.Send(new GetContactByIdQuery { Id = id }));
        }

        //POST api/Contact
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            var response = await _mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Contact/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        //Delete api/Contact/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(DeleteContactCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }
    }
}
