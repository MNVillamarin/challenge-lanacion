using LaNacion.Application.Features.Phones.Commands.CreatePhoneCommand;
using LaNacion.Application.Features.Phones.Commands.DeletePhoneCommand;
using LaNacion.Application.Features.Phones.Commands.UpdatePhoneCommand;
using LaNacion.Application.Features.Phones.Queries.GetPhoneById;
using LaNacion.Application.Features.Phones.Queries.GetPhonesByContactId;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contacts.API.Controllers
{
    public class PhonesController : BaseApiController
    {
        public PhonesController(IMediator mediator) : base(mediator)
        {
        }

        //GET api/Phone/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneById(int id)
        {
            return Ok(await _mediator.Send(new GetPhoneByIdQuery { Id = id }));
        }

        //GET api/Phone/GetPhoneByContactId/id
        [HttpGet("GetPhoneByContactId/{contactId}")]
        public async Task<IActionResult> GetPhoneByContactId(int contactId)
        {
            return Ok(await _mediator.Send(new GetPhoneByContactIdQuery { ContactId = contactId }));
        }

        //POST api/Phone
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePhone(CreatePhoneCommand command)
        {
            var response = await _mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Phone/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhone(UpdatePhoneCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        //Delete api/Phone/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone(DeletePhoneCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }
    }
}
