﻿using MediatR;
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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Application.Interface;

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
            private readonly IHasingSupport _hasingSupport;

            public Handler(DataContext context, IHasingSupport hasingSupport)
            {
                _context = context;
                _hasingSupport = hasingSupport;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //check valid company
                var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);

                if (company == null)
                {
                    throw new UpdateError(System.Net.HttpStatusCode.BadRequest, "Can't find company match with id you send");
                }

                //Check duplicate username
                var checkUsernameAccount = await _context.CompanyAccounts
                    .Include(x => x.Company)
                    .FirstOrDefaultAsync(x => x.Username == request.Username);

                if(checkUsernameAccount != null)
                {
                    throw new UpdateError(System.Net.HttpStatusCode.BadRequest, "Duplicated Username");
                }

                //Check duplicate company code
                var checkCompanyCodeAccount = await _context.CompanyAccounts
                    .Include(x => x.Company)
                    .FirstOrDefaultAsync(x => x.Code == request.Code);

                if (checkCompanyCodeAccount != null)
                {
                    throw new UpdateError(System.Net.HttpStatusCode.BadRequest, "Duplicated Company Code");
                }

                //Hasing pasword
                string hassedPassword = _hasingSupport.encriptSHA256(request.Password);

                var account = new CompanyAccount
                {
                    Code = request.Code,
                    Company = company,
                    Email = request.Email,
                    Fullname = request.Fullname,
                    Password = hassedPassword,
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
