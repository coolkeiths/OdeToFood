using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewController : Controller
    {
        private OdeToFoodDb _db = new OdeToFoodDb();

        //
        // GET: /Review/

        public ActionResult Index([Bind(Prefix="id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if(restaurant == null)
            {
                return HttpNotFound();
            }
            
            return View(restaurant);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        

        //
        // GET: /Review/Create
        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        //
        // POST: /Review/Create

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _db.RestaurantReviews.Add(review);
                    _db.SaveChanges();
                    return RedirectToAction("Index", new { id = review.RestaurantId });
                }
                return View(review);

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
            var review = _db.RestaurantReviews.Find(id);
            return View(review);
        }

        ////
        //// POST: /Review/Edit/5

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });

            }
            return View(review);
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
