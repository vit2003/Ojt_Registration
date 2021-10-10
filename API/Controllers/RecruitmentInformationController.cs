using Application.Recruitment_Informations;
using Application.Recruitment_Informations.CustomizeResponseObject;
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
    [Route("recruitment_informations")]
    [ApiController]
    public class RecruitmentInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecruitmentInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Role: Student
        /// </summary>
        /// <returns>list of recruitment</returns>
        [HttpGet]
        public async Task<List<RecruitmentInListReturn>> ListRecruitment()
        {
            return await _mediator.Send(new ListRecruitment.Query());
        }

        /// <summary>
        /// Role: Student, Company (get detail of recruitment)
        /// </summary>
        /// <param name="id">Id is returned in get list function (id NOT companyId)</param>
        /// <returns>Details of recruitment information follow the input id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<InformationDetail>> Details(string id)
        {
            return await _mediator.Send(new Detail.Query
            {
                Id = int.Parse(id)
            }); ;
        }

        /// <summary>
        /// Role: Company
        /// </summary>
        /// <param name="name">fullname of employee is returned when company login success</param>
        /// <returns></returns>
        [HttpGet("Company/{name}")]
        public async Task<ActionResult<List<RecruitmentInListReturn>>> RecruitmentOfComany(string name)
        {
            return await _mediator.Send(new GetRecruitmentCompany.Query
            {
                Name = name
            });
        }
    }
}
