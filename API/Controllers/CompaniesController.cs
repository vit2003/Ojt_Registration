using Application.Companies;
using Application.Companies.ResponseObject;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Role: Fpt Staff
        /// </summary>
        /// <param name="staffcode">Staff is return in login function</param>
        /// <returns></returns>
        [HttpGet]
        [Route("fptstaff/{staffcode}")]
        public async Task<ActionResult<List<CompanyInList>>> getListCompany(string staffcode)
        {
            return await _mediator.Send(new GetAllCompany.Query { StaffCode = staffcode });
        }
    }
}
