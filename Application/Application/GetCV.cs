using Application.Error;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application
{
    public class GetCv
    {
        public class Query : IRequest<string>
        {
            public string FileName { get; set; }
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
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Cv", request.FileName + ".pdf");
                if(path == null)
                {
                    throw new SearchResultException(System.Net.HttpStatusCode.NotFound, "Could't find Cv file");
                }
                return "https://ojt-registration.herokuapp.com/Cv/"+request.FileName+".pdf";
                //return "https://localhost:44399/Cv/" + request.FileName + ".pdf";
            }
        }
    }
}
