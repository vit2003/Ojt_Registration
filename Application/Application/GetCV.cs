using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application
{
    public class GetCV
    {
        public class Query : IRequest<Byte>
        {
            public string StudentCode { get; set; }
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, Byte>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Byte> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _context.RecruimentApplies.Include(x => x.Student).FirstOrDefaultAsync(x => x.Student.StudentCode == request.StudentCode);

                return application.Cv;
            }
        }
    }
}
