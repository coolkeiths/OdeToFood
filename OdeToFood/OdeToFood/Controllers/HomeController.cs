using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {
            var model = _db.Restaurants.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            AboutModel clsAbout = new AboutModel();
            clsAbout.Name = "Ketan Naik";
            clsAbout.Location = "London United Kingdom";

            return View(clsAbout);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
