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
    public class AddNewCv
    {
        public class Command : IRequest
        {
            public string Cv { get; set; } 
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
                var application = await _context.RecruimentApplies.Include(x => x.Student).FirstOrDefaultAsync(x => x.Student.StudentCode == "SE130092");
                //add cv to application
                application.Cv = request.Cv;
                //update context
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
