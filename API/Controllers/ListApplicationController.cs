using Application.Application;
using Application.Application.CustomizeResponseObject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("listapplications")]
    [ApiController]
    public class ListApplicationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ListApplicationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ApplicationInList>>> ListApplication()
        {
            return await mediator.Send(new ListApp.Query());
        }
    }
}
