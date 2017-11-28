using Anish.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }


        public JsonResult ImageUpload(ProductViewModel model)
        {
            var file = model.ImageFile;
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));
            }
            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ImageSQL(ProductViewModel model)
        {
            var file = model.ImageFile;
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));
            }
            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }


    }
}