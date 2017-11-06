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

        public ActionResult Index()
        {
            var db = new MVCTEntities();
            var list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeViewModel model)
        {
            if(ModelState.IsValid == true)
            {

            }

            var db = new MVCTEntities();
            var list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveRecord(EmployeeViewModel model)
        {
            try
            {
                var db = new MVCTEntities();
                var em = new Employee();

                em.Name = model.Name;
                em.Address = model.Address;
                em.DepartmentId = model.DepartmentId;

                var employee = db.Employees.Add(em);
                db.SaveChanges();

                int latestEmId = em.EmployeeId;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult InserDataIntoMultipleTable(EmployeeViewModel model)
        {
            var db = new MVCTEntities();
            var list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            var emp = new Employee();
            emp.Name = model.Name;
            emp.Address = model.Address;
            emp.DepartmentId = model.DepartmentId;

            db.Employees.Add(emp);
            db.SaveChanges();

            int latestEmpId = emp.EmployeeId;
            var site = new Site();
            site.SiteName = model.SiteName;
            site.EmployeeId = latestEmpId;

            db.Sites.Add(site);
            db.SaveChanges();

            return View(model);
        }

    }
}