using EF02.Data;
using EF02.Models;

namespace EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            #region Question 1: Create Organizer with Profile (1-to-1)
            // Create an Organizer with a related Profile

            //code
            var organizer = new Organizer
            {
                Name = "Tech Corp",
                CompanyName = "Tech Corp Ltd",
                IsVerified = true,
                Profile = new Profile
                {
                    Bio = "We organize tech events",
                    Website = "https://techcorp.com",
                    LogoUrl = "logo.png"
                }
            };

            context.Organizers.Add(organizer);
            context.SaveChanges();

            Console.WriteLine("Organizer with Profile added.");
            #endregion

            #region Question 2: Create Attendee with Badge (1-to-1)
            //create an Attendee with a related Badge

            //code


            var attendee = new Attendee
            {
                FullName = "Ahmed Ali",
                Email = "ahmed@gmail.com",
                Street = "Nasr City",
                City = "Cairo",
                Country = "Egypt",
                PostalCode = "12345",
                Badge = new Badge
                {
                    BadgeNumber = "B123",
                    IssuedDate = DateTime.Now,
                    Tier = "VIP"
                }
            };

            context.Attendees.Add(attendee);
            context.SaveChanges();

            Console.WriteLine("Attendee with Badge added.");
            #endregion


        }
    }
}