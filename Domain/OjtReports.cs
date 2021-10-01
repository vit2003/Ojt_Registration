﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class OjtReports
    {
        public int Id { get; set; }
        public string WorkSortDescription { get; set; }
        public int StudentId { get; set; }
        public int CompanyId { get; set; }
        public double? Mark { get; set; }
        public int? OnWorkDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StudentName { get; set; }
        public string Devision { get; set; }
        public string LineManagerName { get; set; }
        public string StudentEmail { get; set; }


        public virtual Company Company { get; set; }
        public virtual Student Student { get; set; }
    }
}