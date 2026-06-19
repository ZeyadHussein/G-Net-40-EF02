using EF02.Data;
using EF02.Models;

namespace EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            #region Question 1: Organizer with Profile (1-to-1)


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

            Console.WriteLine(" Organizer with Profile added successfully");
            Console.WriteLine("=== Question 1 END ===\n");

            #endregion


            #region Question 2: Attendee with Badge (1-to-1)


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
                    BadgeNumber = "B-1001",
                    IssuedDate = DateTime.Now,
                    Tier = "VIP"
                }
            };

            context.Attendees.Add(attendee);
            context.SaveChanges();

            Console.WriteLine(" Attendee with Badge added successfully");
            Console.WriteLine("=== Question 2 END ===\n");

            #endregion


            #region Question 3: Organizer → Events (1-to-Many)


            var event1 = new Event
            {
                Title = "AI Conference",
                Description = "AI Event",
                StartDate = DateTime.Now,
                MaxAttendees = 100,
                OrganizerId = organizer.OrganizerId
            };

            var event2 = new Event
            {
                Title = "Web Summit",
                Description = "Web Event",
                StartDate = DateTime.Now,
                MaxAttendees = 200,
                OrganizerId = organizer.OrganizerId
            };

            context.Events.AddRange(event1, event2);
            context.SaveChanges();

            Console.WriteLine(" Events added to Organizer");
            Console.WriteLine("=== Question 3 END ===\n");

            #endregion


            #region Question 4: Event → Sessions (1-to-Many)


            var session1 = new Session
            {
                Title = "AI Workshop",
                EventId = event1.EventId
            };

            var session2 = new Session
            {
                Title = "Machine Learning Basics",
                EventId = event1.EventId
            };

            context.Sessions.AddRange(session1, session2);
            context.SaveChanges();

            Console.WriteLine(" Sessions added to Event");
            Console.WriteLine("=== Question 4 END ===\n");

            #endregion


            #region Question 5: Many-to-Many (Registration)


            var registration = new Registration
            {
                AttendeeId = attendee.AttendeeId,
                EventId = event1.EventId,
                RegistrationDate = DateTime.Now,
                Note = "Looking forward to it!"
            };

            context.Registrations.Add(registration);
            context.SaveChanges();

            Console.WriteLine(" Attendee registered to Event");
            Console.WriteLine("=== Question 5 END ===\n");

            #endregion

            #region Question 6: Retrieve Events with Attendees

           

            var eventsWithAttendees = context.Events
                .Select(e => new
                {
                    e.Title,
                    Attendees = e.Registrations.Select(r => r.Attendee.FullName)
                })
                .ToList();

            foreach (var e in eventsWithAttendees)
            {
                Console.WriteLine($"Event: {e.Title}");
                foreach (var name in e.Attendees)
                {
                    Console.WriteLine($" - {name}");
                }
            }

            Console.WriteLine(" Data retrieved successfully");
            Console.WriteLine("=== Question 6 END ===\n");

            #endregion







        }
    }
}