using Anish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class EmployeeOneController : Controller
    {
        public ActionResult Index()
        {
            var db = new MVCTutorialEntities();
            var listEmp = db.Employees
                .Where(e => e.IsDeleted == false)
                .Select(x => new EmployeeViewModel
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Address = x.Address,
                    IsDeleted = x.IsDeleted,
                    DepartmentName = x.Department.DepartmentName,
                }).ToList();
            ViewBag.EmployeeList = listEmp;

            return View();
        }

        /*Add Edit Employee*/
        [HttpPost]
        public ActionResult Index(EmployeeViewModel model)
        {
            try
            {
                var db = new MVCTutorialEntities();
                var list = db.Departments.ToList();
                ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

                if(model.EmployeeId > 0)
                {
                    //Insert
                    var em = db.Employees.SingleOrDefault(e => e.EmployeeId == model.EmployeeId && e.IsDeleted == false);
                    em.Name = model.Name;
                    em.Address = model.Address;
                    em.DepartmentId = model.DepartmentId;
                    db.SaveChanges();
                }

                else
                {
                    //Update
                    var emp = new Employee();
                    emp.Name = model.Name;
                    emp.Address = model.Address;
                    emp.DepartmentId = model.DepartmentId;
                    emp.IsDeleted = false;
                    db.Employees.Add(emp);
                    db.SaveChanges();
                }

            return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public JsonResult DeleteEmployee(int EmployeeId)
        {
            bool result = false;
            var db = new MVCTutorialEntities();
            var emp = db.Employees.SingleOrDefault(x => x.IsDeleted == false && x.EmployeeId == EmployeeId);
            if(emp != null)
            {
                emp.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ShowEmployee(int employeeId)
        {
            var db = new MVCTutorialEntities();

            var listEmp = db.Employees
                .Where(e => e.IsDeleted == false && e.EmployeeId == employeeId)
                .Select(x => new EmployeeViewModel
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Address = x.Address,
                    IsDeleted = x.IsDeleted,
                    DepartmentName = x.Department.DepartmentName,
                }).ToList();
            ViewBag.EmployeeList = listEmp;

            return PartialView("Partial1");
        }


        public ActionResult AddEditEmployee(int employeeId)
        {
            var db = new MVCTutorialEntities();
            var list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            var model = new EmployeeViewModel();

            if(employeeId > 0)
            {
                var em = db.Employees.SingleOrDefault(e => e.EmployeeId == employeeId && e.IsDeleted == false);
                model.EmployeeId = em.EmployeeId;
                model.Name = em.Name;
                model.Address = em.Address;
                model.DepartmentId = em.DepartmentId;
            }
            
            return PartialView("Partial2", model);
        }

        public ActionResult IndexA()
        {
            List<ModelA> List_A = new List<ModelA>();
            List<ModelB> List_B = new List<ModelB>();

            List_A.Add(new ModelA { Name = "Mohsen" });
            List_A.Add(new ModelA { Name = "Joahn" });
            List_A.Add(new ModelA { Name = "Sara" });

            List_B.Add(new ModelB { Country = "US" });
            List_B.Add(new ModelB { Country = "UK" });
            List_B.Add(new ModelB { Country = "CA" });

            ModelC finalItem = new ModelC();
            finalItem.ListA = List_A;
            finalItem.ListB = List_B;
            finalItem.Age = 12;

            return View(finalItem);
        }

        public ActionResult SideMenu()
        {
            var list = new List<MenuItem>();
            list.Add(new MenuItem { Link = "/EmployeeOne/IndexA", LinkName = "Index" });
            list.Add(new MenuItem { Link = "/EmployeeOne/Index", LinkName = "Home" });
            list.Add(new MenuItem { Link = "/Divide/login", LinkName = "LogIn" });
            list.Add(new MenuItem { Link = "/Divide/regesteration", LinkName = "Registeration" });

            return PartialView("SideMenu", list);
        }

        public ActionResult Display()
        {

            return View();
        }

        
    }
}