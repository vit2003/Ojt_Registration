using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class Student
    {
        public Student()
        {
            OjtReports = new HashSet<OjtReport>();
            RecruimentApplies = new HashSet<RecruimentApply>();
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Term { get; set; }
        public int? Credit { get; set; }
        public double? Gpa { get; set; }
        public bool IsPassCriteria { get; set; }
        public int? CompanyId { get; set; }
        public int MajorId { get; set; }
        public string StudentCode { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public virtual Company Company { get; set; }
        public virtual Major Major { get; set; }
        public virtual ICollection<OjtReport> OjtReports { get; set; }
        public virtual ICollection<RecruimentApply> RecruimentApplies { get; set; }
    }
}
