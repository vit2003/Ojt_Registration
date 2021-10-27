using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.RequestObject
{
    public class NewCompanyAccount
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
