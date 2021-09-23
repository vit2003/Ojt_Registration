using Application.Application.CustomizeResponseObject;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application
{
    public class List
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
                var Apply1 = new ApplicationInList
                {
                    Company = "Công ty thương mại điện tử Magezon",
                    Status = "Processing",
                    UpdatedDate = "14/09/2021 15:30"
                };
                var Apply2 = new ApplicationInList
                {
                    Company = "Công ty thương mại điện tử Magezon",
                    Status = "Accepted",
                    UpdatedDate = "15/09/2021 09:25"
                };
                var Apply3 = new ApplicationInList
                {
                    Company = "Công ty thương mại điện tử Magezon",
                    Status = "Rejected",
                    UpdatedDate = "21/09/2021 11:10"
                };
                var result = new List<ApplicationInList> { Apply1, Apply2, Apply3};
                return result;
            }
        }
    }
}
