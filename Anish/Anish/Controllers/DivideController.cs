using Anish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class DivideController : Controller
    {
        // GET: Divide
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registeration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registeration(RegisterationViewModel model)
        {
            var db = new MVCTutorialEntities();
            var siteUser = new SiteUser();

            siteUser.UserName = model.UserName;
            siteUser.Password = model.Password;
            siteUser.Address = model.Address;
            siteUser.EmailId = model.EmailId;
            siteUser.RoleId = 3;

            db.SiteUsers.Add(siteUser);
            db.SaveChanges();

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(RegisterationViewModel model)
        {
            var db = new MVCTutorialEntities();
            var result = "fail";
            var user = db.SiteUsers.SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
            }

            if (user.RoleId == 3)
            {
                result = "GeneralUser";
            }
            else if (user.RoleId == 1)
            {
                result = "Admin";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }


    }
}