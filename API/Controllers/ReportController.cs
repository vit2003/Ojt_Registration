﻿using Application.OjtReport;
using Application.OjtReport.CustomizeResponseObject;
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
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Role: FPT Staff
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ReportDetailInList>>> ReportDetail()
        {
            return await mediator.Send(new ViewOjtReport.Query());
        }
    }
}
