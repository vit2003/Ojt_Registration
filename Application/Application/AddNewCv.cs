using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
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
            public IFormFile Cv { get; set; }
            public string FileName { get; set; }
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
                //Process to save file:
                string fileName = request.FileName;
                if(request.Cv == null)
                {
                    throw new Exception("File not selected");
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Cv" ,fileName+".pdf");
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.Cv.CopyToAsync(stream);
                }
                var application = await _context.RecruimentApplies.Include(x => x.Student).FirstOrDefaultAsync(x => x.Student.StudentCode.Trim() == "SE130092");
                //add cv to application
                application.Cv = fileName;
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
