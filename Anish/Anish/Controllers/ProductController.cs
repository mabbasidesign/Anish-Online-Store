using Anish.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public ActionResult IndexSQL()
        {

            return View();
        }

        public ActionResult IndexURL()
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
            var db = new MVCTutorialEntities();
            var file = model.ImageFile;
            int imageId = 0;
            byte[] imageByte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageByte = reader.ReadBytes(file.ContentLength);
                ImageStore img = new ImageStore();
                img.ImageName = file.FileName;
                img.ImageByte = imageByte;
                img.ImagePath = "/UploadedImage/" + file.FileName;
                img.IsDeleted = false;
                db.ImageStores.Add(img);
                db.SaveChanges();
                imageId = img.ImageId;
            }
            return Json(imageId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ImageUrl(ProductViewModel model)
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            int imageId = 0;
            var file = model.ImageFile;
            byte[] imagebyte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                ImageStore img = new ImageStore();
                img.ImageName = file.FileName;
                img.ImageByte = imagebyte;
                img.ImagePath = "/UploadedImage/" + file.FileName;
                img.IsDeleted = false;
                db.ImageStores.Add(img);
                db.SaveChanges();
                imageId = img.ImageId;
            }
            if (model.ImageUrl != null)
            {
                imagebyte = DownloadImage(model.ImageUrl);
                ImageStore img = new ImageStore();
                img.ImageName = "Abc";
                img.ImageByte = imagebyte;
                img.ImagePath = model.ImageUrl;
                img.IsDeleted = false;
                db.ImageStores.Add(img);
                db.SaveChanges();
                imageId = img.ImageId;
            }
            return Json(imageId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ImageRetrieve(int imgID)
        {
            var db = new MVCTutorialEntities();
            var img = db.ImageStores.SingleOrDefault(x => x.ImageId == imgID);
            return File(img.ImageByte, "image/JPG");
        }
        public byte[] DownloadImage(string url)
        {
            var client = new WebClient();
            byte[] imagebyte = client.DownloadData(url);
            return imagebyte;
        }

    }
}