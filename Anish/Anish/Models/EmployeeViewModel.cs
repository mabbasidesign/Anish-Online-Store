using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anish.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }

    }
}