using Application.Error;
using Application.Interface;
using Application.User.CostomizeResponseObject;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class ProcessRefreshTokens
    {
        public class Command : IRequest<Account>
        {
            [Required]
            public string RefreshToken { get; set; }
            [Required]
            public int Role { get; set; }
        }

        public class Handler : IRequestHandler<Command, Account>
        {
            private readonly DataContext _context;
            private readonly IConfiguration _configuration;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext context, IConfiguration configuration, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _configuration = configuration;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<Account> Handle(Command request, CancellationToken cancellationToken)
            {
                var refreshToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == request.RefreshToken && !x.IsUsed);

                if(refreshToken == null)
                {
                    throw new SearchResultException(System.Net.HttpStatusCode.NotFound, "Invalid refresh token");
                }
                refreshToken.IsUsed = true;
                _context.RefreshToken.Update(refreshToken);
                _context.SaveChanges();
                if (request.Role == 0) //Student login
                {
                    var curUser = await _context.Students.FirstOrDefaultAsync(x => x.Email == refreshToken.Email);
                    if (curUser != null)
                    {
                        var account = await _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname);
                        account.Role = request.Role;
                        account.Code = curUser.StudentCode;
                        return account;
                    }
                    else
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                }
                else if (request.Role == 1) //login for role fpt staff
                {
                    var curUser = await _context.FptStaffs.FirstOrDefaultAsync(x => x.Email == refreshToken.Email);
                    if (curUser == null)
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                    if (curUser != null)
                    {
                        var account = await _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname);
                        account.Role = request.Role;
                        return account;
                    }
                }
                else if (request.Role == 2) //login for role company
                {
                    var curUser = await _context.Companies.FirstOrDefaultAsync(x => x.Email == refreshToken.Email);
                    if (curUser != null)
                    {
                        var account = await _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname);
                        account.Role = request.Role;
                        return account;
                    }
                    else
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                }
                throw new Exception("Invalid refresh token");
            }
        }
    }
}
