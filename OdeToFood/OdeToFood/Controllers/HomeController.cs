using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();


        public ActionResult AutoComplete(string term)
        {
            var model = _db.Restaurants
                        .Where(r => r.Name.Contains(term))
                        .Select(r => new 
                        {
                            label = r.Name
                        });

            return Json(model, JsonRequestBehavior.AllowGet); 
        }


        [OutputCache(CacheProfile="Long")]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            var model = _db.Restaurants
                        .OrderByDescending(r => r.Reviews.Average(x => x.Rating))
                        .Where(r => searchTerm == null || r.Name.Contains(searchTerm))
                        .Select(r => new RestaurantListViewModel
                        {

                            Name = r.Name,
                            ID = r.ID,
                            Country = r.Country,
                            City = r.City,
                            CountOfReviews = r.Reviews.Count()
                        }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurant",model);
            }


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
