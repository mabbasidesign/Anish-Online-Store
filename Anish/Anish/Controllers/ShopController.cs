using System;
using Anish.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anish.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index()
        {
            var db = new MVCTutorialEntities();
            var itemList = new List<MyShop>();
            itemList.Add(new MyShop { ItemId = 1, ItemName = "Rice", IsAvailable = true, });
            itemList.Add(new MyShop { ItemId = 2, ItemName = "Pulse", IsAvailable = false, });
            itemList.Add(new MyShop { ItemId = 3, ItemName = "Salt", IsAvailable = false, });
            itemList.Add(new MyShop { ItemId = 4, ItemName = "Sugar", IsAvailable = true, });
            itemList.Add(new MyShop { ItemId = 5, ItemName = "Soap", IsAvailable = false, });
            itemList.Add(new MyShop { ItemId = 6, ItemName = "Book", IsAvailable = true, });

            ViewBag.ItemList = itemList;

            return View();
        }
    }
}