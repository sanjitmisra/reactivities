using System;
using System.Linq;
using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Activities.Any())
            {
                var activites = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Activity - 1",
                        Category = "Learning",
                        City = "Durban",
                        Description = "Random Act of Learning",
                        Venue = "Royal Academy of Science",
                        Date = DateTime.Now.AddDays(-10)
                    },

                    new Activity
                    {
                        Title = "Activity - 2",
                        Category = "Earning",
                        City = "Paris",
                        Description = "Sell Paintings",
                        Venue = "Louvre",
                        Date = DateTime.Now.AddMonths(2)
                    },

                    new Activity
                    {
                        Title = "Activity - 3",
                        Category = "Fun",
                        City = "Notmandy",
                        Description = "Swim in the open sea",
                        Venue = "The Beach",
                        Date = DateTime.Now.AddMonths(1)
                    },
                };
                context.Activities.AddRange(activites);
                context.SaveChanges();
            }
        }
    }
}