using Anish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            var db = new MVCTutorialEntities();
            var list = db.Employees.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                DepartmentName = x.Department.DepartmentName,
                Address = x.Address,
            }).ToList();

            ViewBag.EmployeeList = list;

            return View();
        }

        public ActionResult GetSerchRegard(string searchtext)
        {
            var db = new MVCTutorialEntities();
            var list = db.Employees.Where(x => x.Name.Contains(searchtext) || x.Department.DepartmentName.Contains(searchtext))
                .Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                DepartmentName = x.Department.DepartmentName,
                Address = x.Address,
            }).ToList();

            return PartialView("SearchPartial", list);
        }

    }
}