using Anish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            Employee employee = new Employee();

            employeeList.Add(new Employee { EmployeeId = 1, Name = "Mohsen", Department = "IT" });
            employeeList.Add(new Employee { EmployeeId = 2, Name = "John", Department = "HR" });
            employeeList.Add(new Employee { EmployeeId = 3, Name = "Smith", Department = "Sales" });
            employeeList.Add(new Employee { EmployeeId = 4, Name = "Bill", Department = "Marketing" });

            //ViewBag.Name = "Mohsen";

            //List<string> list = new List<string>();
            //list.Add("Bob");
            //list.Add("Jorj");
            //list.Add("Tim");
            //list.Add("Mark");
            //list.Add("Frank");
            //list.Add("Richard");

            //ViewBag.NameList = list;

            return View(employeeList);
        }
    }
}