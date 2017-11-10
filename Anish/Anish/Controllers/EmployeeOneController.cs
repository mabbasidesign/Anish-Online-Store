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
                    DepartmentId = x.EmployeeId,
                    Name = x.Name,
                    Address = x.Address,
                    IsDeleted = x.IsDeleted,
                    DepartmentName = x.Department.DepartmentName,
                }).ToList();
            ViewBag.EmployeeList = listEmp;

            return View();
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


    }
}