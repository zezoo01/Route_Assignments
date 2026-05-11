namespace Assgnment02.Models
{
    internal class Attendee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public Badge Badge { get; set; }

        public ICollection<Registration> Registrations { get; set; }
            = new List<Registration>();
    }
}
