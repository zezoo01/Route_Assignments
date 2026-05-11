using Assignment04.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assignment04.Models
{
    public class Account
    {
        [Key]
        [MaxLength(50)]
        public string AccountNumber { get; set; }

        public decimal CurrentBalance { get; set; }

        public AccountType AccountType { get; set; }

        public DateTime OpeningDate { get; set; }

        [Required]
        public string BranchCode { get; set; }

        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
