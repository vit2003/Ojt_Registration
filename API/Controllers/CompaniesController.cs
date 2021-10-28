using Application.Companies;
using Application.Companies.RequestObject;
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
    [Route("companies")]
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

        /// <summary>
        /// Role: Fpt staff
        /// </summary>
        /// <param name="companyId">Company id is return in list of company</param>
        /// <returns></returns>
        [HttpGet]
        [Route("account/{companyId}")]
        public async Task<ActionResult<List<AccountInCompany>>> getAccountOfCompany(int companyId)
        {
            return await _mediator.Send(new GetCompanyAccount.Query { CompanyId = companyId });
        }

        /// <summary>
        /// Role: FPT staff
        /// </summary>
        /// <param name="request">All contain to create new account</param>
        /// <param name="companyId">Id is return in list company</param>
        /// <returns></returns>
        [HttpPost]
        [Route("newaccount/{companyId}")]
        public async Task<ActionResult<Unit>> CreateNewCompanyAccount(NewCompanyAccount request, int companyId)
        {
            var command = new CreateNewCompanyAccount.Command
            {
                Code = request.Code,
                CompanyId = companyId,
                Email = request.Email,
                Fullname = request.Fullname,
                Password = request.Password,
                Username = request.Username
            };
            return await _mediator.Send(command);
        }

        [HttpPost]
        [Route("newcompany")]
        public async Task<ActionResult<Unit>> CreateNewCompanyInfo(CreateNewCompanyInfo.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
