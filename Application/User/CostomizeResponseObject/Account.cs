﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.CostomizeResponseObject
{
    public class Account
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int Role { get; set; }
    }
}
