using Application.User;
using Application.User.CostomizeResponseObject;
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
    [Route("unauthorizes")]
    [ApiController]
    public class UnAuthorizeUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnAuthorizeUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Account>> Login(Login.Query query)
        {
            return await _mediator.Send(query);
        }
    }
}
