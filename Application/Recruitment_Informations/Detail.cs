using Application.Recruitment_Informations.CustomizeResponseObject;
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
    public class Detail
    {
        public class Query : IRequest<InformationDetail>
        {
            public string Id { get; set; }
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
                return new InformationDetail
                {
                    id = 01,
                    Address = "312 Lạc Long Quân, P5, Q11, Tp.HCM",
                    CompanyName = "Công ty thương mại điện tử Magezon",
                    CompanyWebsite = "www.newwaymedia.vn",
                    Content = "- Project Implement skills. \n - Good communication. \n - Ability to effectively handle and solve some problems \n - Capable of teamwork",
                    Deadline = new DateTime(11 / 11 / 2021),
                    MajorName = "SE",
                    Salary = "Thỏa thuận"
                };
            }
        }
    }
}
