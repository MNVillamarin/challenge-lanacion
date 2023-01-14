using LaNacion.Application.Features.Addresses.Commands.CreateAddressCommand;
using LaNacion.Application.Features.Addresses.Commands.DeleteAddressCommand;
using LaNacion.Application.Features.Addresses.Commands.UpdateAddressCommand;
using LaNacion.Application.Features.Addresses.Queries.GetAddressByContactId;
using LaNacion.Application.Features.Addresses.Queries.GetAddressById;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contact.API.Controllers
{
    public class AddressController : BaseApiController
    {
        //GET api/Address/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAddressByIdQuery { Id = id }));
        }

        //GET api/Address/GetAddressByContactId/id
        [HttpGet("GetAddressByContactId/{contactId}")]
        public async Task<IActionResult> GetAddressByContactId(int contactId)
        {
            return Ok(await Mediator.Send(new GetAddressByContactIdQuery { ContactId = contactId }));
        }

        //POST api/Address
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateAddressCommand command)
        {
            var response = await Mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Address/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateAddressCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //Delete api/Address/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(DeleteAddressCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
