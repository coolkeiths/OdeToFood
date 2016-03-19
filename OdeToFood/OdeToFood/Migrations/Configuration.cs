namespace OdeToFood.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OdeToFood.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                 new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                 new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                 new Restaurant
                 {
                     Name = "Smaka",
                     City = "Gothenburg",
                     Country = "Sweden",
                     Reviews =
                         new List<RestaurantReview> {
                            new RestaurantReview  {Rating = 9 , Body = "GreatFood!!!",ReviewerName = "Ketan Naik"}
                        }
                 });


            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = "Restaurant_" + i.ToString(), City = "NoWhere", Country = "USA" });
            }
        }
    }
}
