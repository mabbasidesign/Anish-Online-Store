using System;
using Anish.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Anish.Models
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");

            return View();
        }

        public List<Country> GetCountryList()
        {
            var db = new MVCTutorialEntities();

            var coontries = db.Countries.ToList();
            return coontries;
        }

        public ActionResult GetStateList(int countryId)
        {
            var db = new MVCTutorialEntities();

            var stateList = db.Sstates.Where(e => e.CountryId == countryId).ToList();
            ViewBag.StateOptions = new SelectList(stateList, "StateId", "StateName");

            return PartialView("stateOptionPartial", stateList);
        }
    }
}