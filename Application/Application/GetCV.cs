﻿using Application.Error;
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
    public class GetCV
    {
        public class Query : IRequest<string>
        {
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, string>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _context.RecruimentApplies.Include(x => x.Student).FirstOrDefaultAsync(x => x.Student.StudentCode == "SE130092");

                if(application == null)
                {
                    throw new SearchResultException(System.Net.HttpStatusCode.NotFound, "No CV matches with student code");
                }

                return application.Cv;
            }
        }
    }
}
