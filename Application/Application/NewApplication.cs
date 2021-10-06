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
                var recruitment_information = await _context.RecruitmentInformations.FirstOrDefaultAsync(x => x.Id == request.RecruimentInformationId);

                var student_apply = await _context.Students.FirstOrDefaultAsync(x => x.StudentCode == request.StudentCode);

                var application = new RecruimentApply
                {
                    CoverLetter = request.CoverLetter,
                    Cv = request.Cv,
                    RegistrationDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    Status = "Processing",
                    RecruimentInformationId = request.RecruimentInformationId,
                    StudentId = student_apply.Id,
                    RecruimentInformation = recruitment_information,
                    Student = student_apply,
                };
                _context.RecruimentApplies.Add(application);
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
