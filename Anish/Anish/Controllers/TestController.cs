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


    }
}