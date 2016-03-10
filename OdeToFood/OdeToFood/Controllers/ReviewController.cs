using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewController : Controller
    {

        static List<Review> _lstReviews = new List<Review>
        {
            new Review{
                ID = 1,
                Name = "Hotel Taj",
                City = "Mumbai",
                Rating = "4"
            },
            new Review{
                ID = 4,
                Name = "Centaur",
                City = "Mumbai Juhu",
                Rating = "5"
            },
            new Review{
                ID = 3,
                Name = "Rain Forect",
                City = "Mumbai Ghatkopar",
                Rating = "3"
            },
            new Review{
                ID = 2,
                Name = "Barbeque Nation",
                City = "Mumbai Andheri",
                Rating = "4.5"
            },
        };
        //
        // GET: /Review/

        public ActionResult Index()
        {
            var d = _lstReviews.OrderBy(x => x.ID).ToList();
            return View(d);
        }

        //
        // GET: /Review/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Review/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Review/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Review/Edit/5

        public ActionResult Edit(int id)
        {
            var review = _lstReviews.Single(r => r.ID == id);
            return View(review);
        }

        //
        // POST: /Review/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var review = _lstReviews.Single(x => x.ID == id);
                if (TryUpdateModel(review))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(review);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Review/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Review/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
