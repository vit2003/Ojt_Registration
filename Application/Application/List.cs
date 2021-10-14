﻿using Application.Application.CustomizeResponseObject;
using Application.Error;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application
{
    public class List
    {
        public class Query : IRequest<List<ApplicationInList>>
        {
            public string StaffCode { get; set; }
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, List<ApplicationInList>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<ApplicationInList>> Handle(Query request, CancellationToken cancellationToken)
            {
                var application_list = await _context
                    .RecruimentApplies
                    .Include(x => x.Student)
                    .Include(x => x.RecruimentInformation)
                    .ThenInclude(x => x.Company)
                    .Where(x => x.RegistrationDate > DateTime.UtcNow.AddMonths(-4) && x.RecruimentInformation.Company.Code == request.StaffCode)
                    .ToListAsync();

                if (application_list == null)
                {
                    throw new SearchResultException(System.Net.HttpStatusCode.NotFound, "No application found");
                }
                var result = new List<ApplicationInList>();
                foreach (RecruimentApply listapp in application_list)
                {
                    var applicationlist = new ApplicationInList
                    {
                        Id = listapp.Id,
                        StudentCode = listapp.Student.StudentCode,
                        Fullname = listapp.Student.Fullname,
                        Position = "Interm",
                        Status = listapp.Status,
                        RegistrationDate = listapp.RegistrationDate
                    };
                    result.Add(applicationlist);

                }
                return result;
            }
        }
    }
}
