using Application.OjtReport;
using Application.OjtReport.CustomizeResponseObject;
using Application.OjtReport.RequestObj;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Role: FPT Staff
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ReportDetailInList>>> ReportDetail()
        {
            return await _mediator.Send(new ViewOjtReport.Query());
        }

        /// <summary>
        /// Role: FPT Staff
        /// </summary>
        /// <param name="request">Mark: Greater than 0, Date: Greater than 30, Division: FE,BE,...</param>
        /// <returns></returns>
        [HttpPost]
        [Route("evaluate")]
        public async Task<ActionResult<Unit>> EvaluateStudent(Evaluate request)
        {
            var command = new EvaluateStudent.Command
            {
                CompanyCode = request.CompanyCode,
                Division = request.Division,
                LineManagerName = request.LineManagerName,
                Mark = request.Mark,
                OnWorkDate = request.OnWorkDate,
                StudentCode = request.StudentCode,
                WorkSortDescription = request.WorkSortDescription
            };
            return await _mediator.Send(command);
        } 
    }
}
