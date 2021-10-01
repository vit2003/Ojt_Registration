using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.OjtReport.CustomizeResponseObject;
using Persistence;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Application.Error;
using Domain;

namespace Application.OjtReport
{

    public class ViewOjtReport
    {
        public class Query : IRequest<List<ReportDetail>>
        {
            
        }
        public class Handler : IRequestHandler<Query, List<ReportDetail>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<ReportDetail>> Handle(Query request, CancellationToken cancellationToken)

            {
                var report_details = await _context.OjtReports.Include(x => x.Student).ToListAsync();
                if(report_details == null)
                {
                    throw new SearchResultException(System.Net.HttpStatusCode.NotFound, "No report found");
                }
                var result = new List<ReportDetail>();
                foreach(OjtReports report in report_details)
                {
                    var report_detail = new ReportDetail
                    {
                        StudentCode = report.Student.StudentCode,
                        StudentName = report.Student.Fullname,
                        Mark = report.Mark,
                        WorkSortDescription = report.WorkSortDescription
                    };
                    result.Add(report_detail);
                    
                }
                return result;

            }
              
        }
    }
    } 

