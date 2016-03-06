using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        [HttpPost]
        public ActionResult Search(string name = "French")
        {

            var message = Server.HtmlDecode(name);
            return Content(message);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return Content("Get method Called");
        }

    }
}
