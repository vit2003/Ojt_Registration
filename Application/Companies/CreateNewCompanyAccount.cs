using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Application.Error;

namespace Application.Companies
{
    public class CreateNewCompanyAccount
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public string Fullname { get; set; }
            public string Username { get; set; }
            public string Code { get; set; }
            public string Password { get; set; }
            public int CompanyId { get; set; }
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
                var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);

                if(company == null)
                {
                    throw new UpdateError(System.Net.HttpStatusCode.BadRequest, "Can't find company match with id you send");
                }

                var account = new CompanyAccount
                {
                    Code = request.Code,
                    Company = company,
                    Email = request.Email,
                    Fullname = request.Fullname,
                    Password = request.Password,
                    Username = request.Username
                };

                _context.CompanyAccounts.Add(account);

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
