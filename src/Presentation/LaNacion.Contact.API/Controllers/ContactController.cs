using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contact.API.Controllers
{
    public class ContactController : BaseApiController
    {
        //POST api/Contact
        [HttpPost]
        public async Task<IActionResult> Post(CreateContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
