﻿using Application.Application;
using Application.Application.CustomizeResponseObject;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationInList>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> NewApplication(NewApplication.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
