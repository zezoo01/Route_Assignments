using Assignment04.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment04.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@bank.com",
                    PhoneNumber = "01000000001",
                    HireDate = new DateTime(2020, 1, 10)
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Sara Ali",
                    Email = "sara@bank.com",
                    PhoneNumber = "01000000002",
                    HireDate = new DateTime(2021, 5, 15)
                }
            );

            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Code = "CAI-01",
                    Name = "Cairo Main Branch",
                    Address = "Cairo",
                    PhoneNumber = "022222222",
                    ManagerId = 1
                },
                new Branch
                {
                    Code = "ALX-01",
                    Name = "Alex Branch",
                    Address = "Alexandria",
                    PhoneNumber = "033333333",
                    ManagerId = 2
                }
            );
        }
    }
}
