using Assignment04.Enums;

namespace Assignment04.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string AccountNumber { get; set; }

        public Account Account { get; set; }

        public DateTime OwnershipStartDate { get; set; }

        public OwnershipType OwnershipType { get; set; }

        public AccountStatus AccountStatus { get; set; }
    }
}
