using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.RequestObject
{
    public class NewCompany
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string WebSite { get; set; }
        [Required]
        public string HostManagerEmail { get; set; }
        [Required]
        public DateTime LastInteractDate { get; set; }
    }
}
