using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public string Rating { get; set; }
        public int RestaurantId { get; set; }
    }
}