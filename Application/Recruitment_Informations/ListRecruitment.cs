using Domain;
using MediatR;
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
        //get access to db context
        public class Handler : IRequestHandler<Query, List<RecruitmentInListReturn>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<RecruitmentInListReturn>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<RecruitmentInListReturn> result = new List<RecruitmentInListReturn>();
                RecruitmentInListReturn re1 = new RecruitmentInListReturn
                {
                    Id = 1,
                    Area = "Tp. Hồ Chí Minh",
                    CompanyName = "Công ty thương mại điện tử Magezon",
                    Deadline = new DateTime(20 / 09 / 2021),
                    MajorName = "SE",
                    Salary = "Thỏa thuận",
                    Topic = "Thực tập sinh Backend Engineer (PHP/NodeJs/C#/Java/Ruby/Go)"
                };
                result.Add(re1);
                RecruitmentInListReturn re2 = new RecruitmentInListReturn
                {
                    Id = 2,
                    Area = "Quận 9",
                    CompanyName = "Công ty thương mại điện tử Magezon",
                    Deadline = new DateTime(25 / 09 / 2021),
                    MajorName = "Ai",
                    Salary = "Thỏa thuận",
                    Topic = "Thực tập sinh Python"
                };
                result.Add(re2);
                RecruitmentInListReturn re3 = new RecruitmentInListReturn
                {
                    Id = 3,
                    Area = "Tp. Hồ Chí Minh",
                    CompanyName = "CÔNG TY TNHH MONEY FORWARD VIỆT NAM",
                    Deadline = new DateTime(30 / 09 / 2021),
                    MajorName = "SS",
                    Salary = "Thỏa thuận",
                    Topic = "Nhân viên bán hàng"
                };
                result.Add(re3);
                return result;
            }
        }
    }
}
