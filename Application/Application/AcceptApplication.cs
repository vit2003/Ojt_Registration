using Application.Error;
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
    public class AcceptApplication
    {
        public class Command : IRequest
        {
            public string CompanyCode { get; set; }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _context
                    .RecruimentApplies
                    .Include(x => x.Student)
                    .Include(x => x.RecruimentInformation)
                    .ThenInclude(x => x.Company)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (application.RecruimentInformation.Company.Code != request.CompanyCode)
                {
                    throw new UpdateError(System.Net.HttpStatusCode.BadRequest, "Application not related to your company");
                }

                application.Status = "Approved";
                application.Student.WorkingStatus = "Working";

                _context.RecruimentApplies.Update(application);

                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("Problem save changes");
            }
        }
    }
}
