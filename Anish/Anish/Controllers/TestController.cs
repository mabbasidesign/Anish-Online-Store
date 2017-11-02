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
            employeeList.Add(new Employee { EmployeeId = 4, Name = "Bill", Department = "" });

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

        public ActionResult Map()
        {
            AnishEntities1 db = new AnishEntities1();
            Employee employee = db.Employees.SingleOrDefault(x => x.EmployeeId == 1);

            EmployeeViewModel employeeVM = new EmployeeViewModel();

            employeeVM.EmployeeId = employee.EmployeeId;
            employeeVM.DepartmentId = employee.DepartmentId;
            employeeVM.Name = employee.Name;
            employeeVM.Address = employee.Address;

            return View(employeeVM);
        }

        public ActionResult MultipleTable()
        {
            AnishEntities1 db = new AnishEntities1();
            List<Employee> employeeList = db.Employees.ToList();

            var employeeVM = new EmployeeViewModel();
            var employeeVmList = employeeList.Select(x => new EmployeeViewModel
            {
                Name = x.Name,
                Address = x.Address,
                EmployeeId = x.EmployeeId,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department1.Name}).ToList();

            return View(employeeVmList);
        }

    }
}