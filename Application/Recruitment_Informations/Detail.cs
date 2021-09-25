using Application.Recruitment_Informations.CustomizeResponseObject;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recruitment_Informations
{
    public class Detail
    {
        public class Query : IRequest<InformationDetail>
        {
            public int Id { get; set; }
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, InformationDetail>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<InformationDetail> Handle(Query request, CancellationToken cancellationToken)
            {
                var information_detail = await _context.RecruitmentInformations.FirstOrDefaultAsync(x => x.Id == request.Id);

                var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == information_detail.CompanyId);

                var major = await _context.Majors.FirstOrDefaultAsync(x => x.Id == information_detail.MajorId);

                return new InformationDetail
                {
                    Address = company.Address,
                    CompanyName = company.CompanyName,
                    CompanyWebsite = company.WebSite,
                    Content = information_detail.Content,
                    Deadline = information_detail.Deadline,
                    id = information_detail.Id,
                    MajorName = major.MajorName,
                    Salary = information_detail.Salary
                };
            }
        }
    }
}
