using System.ComponentModel.DataAnnotations;

namespace Assignment04.Models
{
    public class Branch
    {
        [Key]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
