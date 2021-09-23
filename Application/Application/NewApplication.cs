using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application
{
    public class NewApplication
    {
        public class Command : IRequest
        {
            public Byte Cv { get; set; }
            public int? RecruimentInformationId { get; set; }
            public string StudentCode { get; set; }
            public string StudentName { get; set; }
            public string CoverLetter { get; set; }
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
                //handler logic 
                //var success = await _context.SaveChangesAsync() > 0;
                //if (success)
                //{
                    return Unit.Value;
                //}
                //throw new Exception("Problem save changes");
            }
        }
    }
}
