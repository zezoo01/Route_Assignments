using Assgnment02.Models;

namespace Assgnment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicatonDbContext();

            context.Database.EnsureCreated();

            var organizer = new Organizer
            {
                Name = "Tech Events",
                CompanyName = "Tech Corp",
                IsVerified = true,

                Profile = new OrganizerProfile
                {
                    Biography = "We organize technology conferences",
                    WebsiteUrl = "https://techcorp.com",
                    LogoPath = "logo.png"
                }
            };

            var eventItem = new Event
            {
                Title = "AI Conference 2026",
                Description = "Big AI Event",
                StartDate = DateTime.Now.AddDays(10),
                MaxAttendees = 500,
                Organizer = organizer
            };

            var attendee = new Attendee
            {
                FullName = "Ahmed Ali",
                Email = "ahmed@test.com",

                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Cairo",
                    Country = "Egypt",
                    PostalCode = "11511"
                }
            };

            var registration = new Registration
            {
                Attendee = attendee,
                Event = eventItem,
                Note = "Looking forward to attending",
                RegisteredAt = DateTime.Now
            };

            context.Registrations.Add(registration);

            context.SaveChanges();

            Console.WriteLine("Database Created Successfully");
        }
    }
}
