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
            ViewBag.Name = "Mohsen";

            List<string> list = new List<string>();
            list.Add("Bob");
            list.Add("Jorj");
            list.Add("Tim");
            list.Add("Mark");
            list.Add("Frank");
            list.Add("Richard");

            ViewBag.NameList = list;

            return View();
        }
    }
}