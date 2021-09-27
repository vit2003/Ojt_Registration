using Application.Error;
using Application.Interface;
using Application.User.CostomizeResponseObject;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<Account>
        {
            public string FireBaseToken { get; set; }
            public int Role { get; set; }
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, Account>
        {
            private readonly DataContext _context;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IFirebaseSupport _firebaseSupport;

            public Handler(DataContext context, IJwtGenerator jwtGenerator, IFirebaseSupport firebaseSupport)
            {
                _context = context;
                _jwtGenerator = jwtGenerator;
                _firebaseSupport = firebaseSupport;
            }
            public async Task<Account> Handle(Query request, CancellationToken cancellationToken)
            {
                //init firebase
                _firebaseSupport.initFirebase();
                //get user from firebase token
                var email = await _firebaseSupport.getEmailFromToken(request.FireBaseToken);
                //check if token error:
                if(email.Contains("Firebase Exception:"))
                {
                    throw new FirebaseLoginException(HttpStatusCode.BadRequest, email.Substring(20));
                }
                //process login
                if (request.Role == 0)
                {
                    var curUser = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
                    if(curUser != null)
                    {
                        return new Account
                        {
                            Code = curUser.StudentCode,
                            Role = request.Role,
                            Name = curUser.Fullname,
                            Token = _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname)
                        };
                    } else
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                } else if (request.Role == 1)
                {
                    var curUser = await _context.FptStaffs.FirstOrDefaultAsync(x => x.Email == email);
                    if (curUser == null)
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                    if (curUser != null)
                    {
                        return new Account
                        {
                            Role = request.Role,
                            Name = curUser.Fullname,
                            Token = _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname)
                        };
                    }
                } else if (request.Role == 2)
                {
                    var curUser = await _context.Companies.FirstOrDefaultAsync(x => x.Email == email);
                    if(curUser != null)
                    {
                        return new Account
                        {
                            Role = request.Role,
                            Name = curUser.Fullname,
                            Token = _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname)
                        };
                    }
                    else
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                }
                throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
            }
        }
    }
}
