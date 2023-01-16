using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contacts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
