using System.ComponentModel.DataAnnotations;

namespace Assgnment02.Models
{
    internal class OrganizerProfile
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Biography { get; set; }

        [MaxLength(200)]
        public string WebsiteUrl { get; set; }

        public string LogoPath { get; set; }

        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; }
    }
}
