﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.Contact.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
