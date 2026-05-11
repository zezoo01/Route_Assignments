using System.ComponentModel.DataAnnotations;

namespace Assignment04.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public Branch Branch { get; set; }
    }
}
