using EF02.Data;
using EF02.Models;

namespace EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            #region Question 1: Create Organizer with Profile (1-to-1)
            // create orgainzer         
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
        }
    }
}
