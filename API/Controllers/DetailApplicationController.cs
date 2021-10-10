using Application.Application;
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
    [Route("detailapplications")]
    [ApiController]
    public class DetailApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DetailApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ApplicationInList>> DetailApp()
        {
            return await _mediator.Send(new ListApp.Query());
        }

        [HttpGet("{id}")]
        public async Task<DetailApplication> Details(string id)
        {
            return await _mediator.Send(new DetailApply.Query
            {
                Id = int.Parse(id)
            }); ;
        }
    }
}
