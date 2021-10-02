﻿using Application.Error;
using Application.Interface;
using Application.User.CostomizeResponseObject;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Net;
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
                if (request.Role == 0) //Student login
                {
                    var curUser = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
                    if(curUser != null)
                    {
                        var account = await _jwtGenerator.CreateToken(curUser.Email, curUser.Fullname);
                        account.Role = request.Role;
                        account.Code = curUser.StudentCode;
                        return account;
                    } else
                    {
                        throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
                    }
                } else if (request.Role == 1) //login for role fpt staff
                {
                    var curUser = await _context.FptStaffs.FirstOrDefaultAsync(x => x.Email == email);
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
                } else if (request.Role == 2) //login for role company
                {
                    var curUser = await _context.Companies.FirstOrDefaultAsync(x => x.Email == email);
                    if(curUser != null)
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
                throw new FirebaseLoginException(HttpStatusCode.Unauthorized, "Unexisted Account");
            }
        }
    }
}
