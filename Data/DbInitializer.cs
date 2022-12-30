using ActivitiesCQRS.Models;

namespace ActivitiesCQRS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ActivityContext context)
        {

            ///If there are no records in Activity tables 

            if (context.Activitys.Any())
            {
                return;   // DB has been seeded
            }



            var Activitys = new Activity[]
            {
                new Activity
                    {
                    Title = "Activity 1",
                        Date = DateTime.UtcNow,
                        Description = "Activity 1 Description",
                        Category = "Category 1",
                        City = "City 1",
                        Venue = "Venue 1"

                    },
                new Activity
                    {
                       Title = "Activity 2",
                        Date = DateTime.UtcNow,
                        Description = "Activity 2 Description",
                        Category = "Category 2",
                        City = "City 2",
                        Venue = "Venue 2"

                    },
                new Activity
                    {
                    Title = "Activity 4",
                    Date = DateTime.UtcNow,
                    Description = "Activity 3 Description",
                    Category = "Category 3",
                    City = "City 3",
                        Venue = "Venue 3"

                        }
            };

            ///The Activity objects are added to the object graph with AddRange.
            context.Activitys.AddRange(Activitys);
            ///The object graph changes are committed to the database with SaveChanges.

            context.SaveChanges();
        }
    }
}