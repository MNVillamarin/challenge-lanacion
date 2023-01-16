using LaNacion.Application.Features.Addresses.Commands.CreateAddressCommand;
using LaNacion.Application.Features.Addresses.Commands.DeleteAddressCommand;
using LaNacion.Application.Features.Addresses.Commands.UpdateAddressCommand;
using LaNacion.Application.Features.Addresses.Queries.GetAddressByContactId;
using LaNacion.Application.Features.Addresses.Queries.GetAddressById;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contacts.API.Controllers
{
    public class AddressesController : BaseApiController
    {
        public AddressesController(IMediator mediator) : base(mediator)
        {
        }

        //GET api/Address/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            return Ok(await _mediator.Send(new GetAddressByIdQuery { Id = id }));
        }

        //GET api/Address/GetAddressByContactId/id
        [HttpGet("GetAddressByContactId/{contactId}")]
        public async Task<IActionResult> GetAddressByContactId(int contactId)
        {
            return Ok(await _mediator.Send(new GetAddressByContactIdQuery { ContactId = contactId }));
        }

        //POST api/Address
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var response = await _mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Address/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        //Delete api/Address/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            return Ok(await _mediator.Send(new DeleteAddressCommand { Id = id }));
        }
    }
}
