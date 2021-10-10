﻿using Application.Application;
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
    [Route("applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ApplicationInList>>> List()
        {
            return await _mediator.Send(new ListApp.Query());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> NewApplication(NewApplication.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
