using Application.User.CostomizeResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IJwtGenerator
    {
        Task<Account> CreateToken(string email, string name);
    }
}
