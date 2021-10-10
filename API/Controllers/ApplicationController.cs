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
    [Route("applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet]
        //public async Task<ActionResult<List<ApplicationInList>>> List()
        //{
        //    return await _mediator.Send(new List.Query());
        //}
        //[HttpPost]
        //public async Task<ActionResult<Unit>> NewApplication(NewApplication.Command command)
        //{
        //    return await _mediator.Send(command);
        //}

        /// <summary>
        /// Get cái CV vừa add
        /// </summary>
        /// <returns></returns>
        [HttpGet("CV")]
        public async Task<ActionResult<string>> GetCV()
        {
            return await _mediator.Send(new GetCV.Query());
        }

        /// <summary>
        /// Để Tú test add CV
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("cv")]
        public async Task<ActionResult<Unit>> AddNewCv([FromBody]AddNewCv.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
