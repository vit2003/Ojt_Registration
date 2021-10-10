﻿using Application.Application.CustomizeResponseObject;
using Application.Error;
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
    public class ListApp
    {
        public class Query : IRequest<List<ApplicationInList>>
        {

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
                var application_list = await _context.RecruimentApplies.Include(x => x.Student).ToListAsync();
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
                        Position = listapp.Position,
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
