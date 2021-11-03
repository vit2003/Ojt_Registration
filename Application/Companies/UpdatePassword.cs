using Application.Interface;
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
    public class UpdatePassword
    {
        public class Command : IRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IHasingSupport _hasingSupport;

            public Handler(DataContext context,IHasingSupport hasingSupport)
            {

                _context = context;
                _hasingSupport = hasingSupport;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var account = await _context.CompanyAccounts.FirstOrDefaultAsync(x => x.Username == request.Username);

                if(request.Password != null && request.Password.Length > 0)
                {
                    string hasingPassword = _hasingSupport.encriptSHA256(request.Password);
                    account.Password = hasingPassword;
                }
                
                _context.CompanyAccounts.Update(account);
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
