using Application.Students.CustomizeResponseObject;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    public class StudentInfo
    {
        public class Query : IRequest<StudentDetailReturn>
        {
            public string Email { get; set; }
        }
        //get access to db context
        public class Handler : IRequestHandler<Query, StudentDetailReturn>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<StudentDetailReturn> Handle(Query request, CancellationToken cancellationToken)
            {
                return new StudentDetailReturn
                {
                    Address = "ab/c Pvh, Tb, HCM",
                    BirthDate = new DateTime(10 / 10 / 1999),
                    Email = "tultse130223@fpt.edu.vn",
                    FullName = "Lê Thanh Tú",
                    Gender = "Female",
                    Major = "SE",
                    Phone = "0912345678",
                    StuCode = "SE130223",
                    Term = 10
                };
            }
        }
    }
}
