using Assignment04.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assignment04.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        [MaxLength(250)]
        public string Note { get; set; }

        public string AccountNumber { get; set; }

        public Account Account { get; set; }
    }
}
