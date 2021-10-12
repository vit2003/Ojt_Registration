using Application.Application;
using Application.Application.CustomizeResponseObject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Role: Student
        /// </summary>
        /// <param name="command">Application:</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Unit>> NewApplication(NewApplication.Command command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Get Cv follow file name
        /// </summary>
        /// <param name="fileName">File name (cái mà lúc tạo truyền vào)</param>
        /// <returns></returns>
        [HttpGet("CV/{fileName}")]
        public async Task<ActionResult<string>> GetCV(string fileName)
        {
            return await _mediator.Send(new GetCv.Query { FileName = fileName });
        }

        /// <summary>
        /// Test Add Cv
        /// </summary>
        /// <param name="cv">File Cv</param>
        /// <param name="fileName">Tên của file để tí get</param>
        /// <returns></returns>
        [HttpPost("cv/{fileName}")]
        public async Task<ActionResult<Unit>> AddNewCv(IFormFile cv, string fileName)
        {
            return await _mediator.Send(new AddNewCv.Command { Cv = cv, FileName = fileName });
        }
    }
}
