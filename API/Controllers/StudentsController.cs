using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Students;
using Application.Students.CustomizeResponseObject;

namespace API.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Code}")]
        public async Task<ActionResult<StudentDetailReturn>> StudentInfo(string Code)
        {
            return await _mediator.Send(new StudentInfo.Query
            {
                StudentCode = Code
            });
        }
    }
}
