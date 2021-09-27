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
    [Route("api/recruitment_informations")]
    [ApiController]
    public class RecruitmentInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecruitmentInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<RecruitmentInListReturn>> ListRecruitment()
        {
            return await _mediator.Send(new ListRecruitment.Query());
        }

        [HttpGet("{id}")]
        public async Task<InformationDetail> Details(string id)
        {
            return await _mediator.Send(new Detail.Query
            {
                Id = int.Parse(id)
            }); ;
        }
    }
}
