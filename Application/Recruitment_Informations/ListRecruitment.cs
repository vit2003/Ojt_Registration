using Application.Recruitment_Informations.CustomizeResponseObject;
using Domain;
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
    public class ListRecruitment
    {
        public class Query : IRequest<List<RecruitmentInListReturn>>
        {

        }
        public class Handler : IRequestHandler<Query, List<RecruitmentInListReturn>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<RecruitmentInListReturn>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list_recruitment = await _context.RecruitmentInformations.Include(x => x.Company).Where(x => x.Deadline >= DateTime.Now).ToListAsync();

                var list_major = await _context.Majors.ToListAsync();
                List<RecruitmentInListReturn> result = new List<RecruitmentInListReturn>();

                foreach(RecruitmentInformation infor in list_recruitment)
                {
                    var recruitment = new RecruitmentInListReturn
                    {
                        Area = infor.Area,
                        CompanyName = infor.Company.CompanyName,
                        Deadline = infor.Deadline,
                        Id = infor.Id,
                        MajorName = getMajorName(list_major, infor.Id),
                        Salary = infor.Salary,
                        Topic = infor.Topic
                    };
                    result.Add(recruitment);
                }
                return result;
            }
            private string getMajorName(List<Major> list, int id)
            {
                string result = "";
                foreach (Major major in list)
                {
                    if (major.Id == id)
                    {
                        result = major.MajorName;
                        break;
                    }
                }
                return result;
            }
        }
    }
}
