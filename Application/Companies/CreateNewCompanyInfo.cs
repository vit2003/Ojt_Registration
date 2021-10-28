using Application.Error;
using Application.Interface;
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

namespace Application.Companies
{
    public class CreateNewCompanyInfo
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string WebSite { get; set; }
            public string HostManagerEmail { get; set; }
            public DateTime LastInteractDate { get; set; }
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
                if(request.CompanyName == null)
                {
                    throw new Exception("CompanyName cannot be empty");
                }
                if (request.Address == null)
                {
                    throw new Exception("Address cannot be empty");
                }
                if (request.WebSite == null)
                {
                    throw new Exception("Website of company cannot be empty");
                }
                if (request.HostManagerEmail == null)
                {
                    throw new Exception("HostManagerEmail cannot be empty");
                }

                var infomation = new Company
                {
                    CompanyName = request.CompanyName,
                    Address = request.Address,
                    WebSite = request.WebSite,
                    HostManagerEmail = request.HostManagerEmail,
                    LastInteractDate = DateTime.Now
                };

                _context.Companies.Add(infomation);

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
