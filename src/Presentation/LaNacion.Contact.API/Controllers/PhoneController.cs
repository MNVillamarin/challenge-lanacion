using LaNacion.Application.Features.Phones.Commands.CreatePhoneCommand;
using LaNacion.Application.Features.Phones.Commands.DeletePhoneCommand;
using LaNacion.Application.Features.Phones.Commands.UpdatePhoneCommand;
using LaNacion.Application.Features.Phones.Queries.GetPhoneById;
using LaNacion.Application.Features.Phones.Queries.GetPhonesByContactId;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contact.API.Controllers
{
    public class PhoneController : BaseApiController
    {
        //GET api/Phone/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPhoneByIdQuery { Id = id }));
        }

        //GET api/Phone/GetPhoneByContactId/id
        [HttpGet("GetPhoneByContactId/{contactId}")]
        public async Task<IActionResult> GetPhoneByContactId(int contactId)
        {
            return Ok(await Mediator.Send(new GetPhoneByContactIdQuery { ContactId = contactId }));
        }

        //POST api/Phone
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreatePhoneCommand command)
        {
            var response = await Mediator.Send(command);
            return Created(Request.GetEncodedUrl() + "/" + response.Data, response);
        }

        //PUT api/Phone/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdatePhoneCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //Delete api/Phone/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(DeletePhoneCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
