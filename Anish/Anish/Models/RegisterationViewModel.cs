﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anish.Models
{
    public class RegisterationViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Nullable<int> RoleId { get; set; }

    }
}