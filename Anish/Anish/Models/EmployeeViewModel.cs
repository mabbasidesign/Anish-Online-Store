﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Anish.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required (ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public Nullable<int> DepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        //Custom attribute
        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }

    }
}