using Assignment04.Context;
using Assignment04.Enums;
using Assignment04.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();
            db.Database.Migrate();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       National Bank - Management       ");
                Console.WriteLine("========================================");
                Console.WriteLine("  1) Add a new Customer");
                Console.WriteLine("  2) Open a new Account for a Customer");
                Console.WriteLine("  3) Update Account Status (Active / Closed)");
                Console.WriteLine("  4) Remove an Account from a Customer");
                Console.WriteLine("  5) List all Customers (with accounts)");
                Console.WriteLine("  0) Exit");
                Console.WriteLine("----------------------------------------");
                Console.Write("  Enter choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\n  [!] Invalid input. Please enter a number.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1: AddCustomer(db); break;
                    case 2: OpenAccount(db); break;
                    case 3: UpdateAccountStatus(db); break;
                    case 4: RemoveAccountFromCustomer(db); break;
                    case 5: ListCustomers(db); break;
                    case 0: running = false; break;
                    default:
                        Console.WriteLine("\n  [!] Invalid choice. Please choose from the menu.");
                        Pause();
                        break;
                }
            }

            Console.WriteLine("\n  Goodbye!");
        }

        static void AddCustomer(AppDbContext db)
        {
            Console.WriteLine("\n--- Add New Customer ---");

            string fullName = ReadNonEmpty("Full Name      : ");
            string nationalId = ReadNonEmpty("National ID    : ");

            DateTime dob;
            while (true)
            {
                Console.Write("Date of Birth  : (yyyy-MM-dd) ");
                string dobInput = Console.ReadLine();
                if (DateTime.TryParseExact(dobInput, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out dob))
                    break;
                Console.WriteLine("  [!] Invalid date format. Use yyyy-MM-dd.");
            }

            string email = ReadNonEmpty("Email          : ");
            string phone = ReadNonEmpty("Phone          : ");
            string address = ReadNonEmpty("Address        : ");

            Console.WriteLine("Customer Type:");
            Console.WriteLine("     1) Individual");
            Console.WriteLine("     2) Business");
            int typeChoice = ReadMenuChoice("  Choice", 1, 2);
            CustomerType customerType = typeChoice == 1 ? CustomerType.Individual : CustomerType.Business;

            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dob,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCustomer created successfully. CustomerId = {customer.Id}");
            Console.ResetColor();
            Pause();
        }

        static void OpenAccount(AppDbContext db)
        {
            Console.WriteLine("\n--- Open New Account ---");

            string accountNumber = ReadNonEmpty("Account Number : ");

            Console.WriteLine("Account Type:");
            Console.WriteLine("     1) Savings");
            Console.WriteLine("     2) Current");
            Console.WriteLine("     3) Business");
            int typeChoice = ReadMenuChoice("  Choice", 1, 3);
            AccountType accountType = (AccountType)typeChoice;

            string branchCode = ReadNonEmpty("Branch Code    : ");
            int customerId = ReadInt("Customer Id    : ");

            Console.WriteLine("Ownership Role:");
            Console.WriteLine("     1) Primary");
            Console.WriteLine("     2) CoHolder");
            int ownerChoice = ReadMenuChoice("  Choice", 1, 2);
            OwnershipType ownershipType = ownerChoice == 1 ? OwnershipType.Primary : OwnershipType.CoHolder;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nValidating branch '{branchCode}' and customer #{customerId}...");
            Console.ResetColor();

            var branch = db.Branches.Find(branchCode);
            if (branch == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  [!] Branch '{branchCode}' not found.");
                Console.ResetColor();
                Pause();
                return;
            }

            var customer = db.Customers.Find(customerId);
            if (customer == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  [!] Customer #{customerId} not found.");
                Console.ResetColor();
                Pause();
                return;
            }

            if (db.Accounts.Any(a => a.AccountNumber == accountNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  [!] Account '{accountNumber}' already exists.");
                Console.ResetColor();
                Pause();
                return;
            }

            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                CurrentBalance = 0,
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };

            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipStartDate = DateTime.Now,
                OwnershipType = ownershipType,
                AccountStatus = AccountStatus.Active
            };

            db.Accounts.Add(account);
            db.CustomerAccounts.Add(customerAccount);
            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Account '{accountNumber}' created and linked to customer {customerId} as {ownershipType} owner.");
            Console.ResetColor();
            Pause();
        }

        static void UpdateAccountStatus(AppDbContext db)
        {
            Console.WriteLine("\n--- Update Account Status ---");

            string accountNumber = ReadNonEmpty("Account Number : ");
            int customerId = ReadInt("Customer Id    : ");

            var ca = db.CustomerAccounts
                .FirstOrDefault(x => x.AccountNumber == accountNumber && x.CustomerId == customerId);

            if (ca == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  [!] No matching account/customer link found.");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.WriteLine("New Status:");
            Console.WriteLine("     1) Active");
            Console.WriteLine("     2) Closed");
            int statusChoice = ReadMenuChoice("  Choice", 1, 2);
            ca.AccountStatus = statusChoice == 1 ? AccountStatus.Active : AccountStatus.Closed;

            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nStatus updated to {ca.AccountStatus}.");
            Console.ResetColor();
            Pause();
        }

        static void RemoveAccountFromCustomer(AppDbContext db)
        {
            Console.WriteLine("\n--- Remove Account From Customer ---");

            string accountNumber = ReadNonEmpty("Account Number : ");
            int customerId = ReadInt("Customer Id    : ");

            var ca = db.CustomerAccounts
                .FirstOrDefault(x => x.AccountNumber == accountNumber && x.CustomerId == customerId);

            if (ca == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  [!] No matching account/customer link found.");
                Console.ResetColor();
                Pause();
                return;
            }

            db.CustomerAccounts.Remove(ca);
            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Ownership link deleted.");
            Console.ResetColor();

            bool hasOtherOwners = db.CustomerAccounts.Any(x => x.AccountNumber == accountNumber);
            if (!hasOtherOwners)
            {
                var account = db.Accounts.Find(accountNumber);
                if (account != null)
                {
                    db.Accounts.Remove(account);
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"      That was the last owner — account '{accountNumber}' was also removed.");
                    Console.ResetColor();
                }
            }

            Pause();
        }

        static void ListCustomers(AppDbContext db)
        {
            Console.WriteLine("\n--- All Customers ---\n");

            var customers = db.Customers
                .Include(c => c.CustomerAccounts)
                    .ThenInclude(ca => ca.Account)
                        .ThenInclude(a => a.Branch)
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("  (no customers found)");
                Pause();
                return;
            }

            foreach (var c in customers)
            {
                Console.WriteLine($"  #{c.Id} {c.FullName} ({c.CustomerType})");

                if (!c.CustomerAccounts.Any())
                {
                    Console.WriteLine("       (no accounts)");
                }
                else
                {
                    foreach (var ca in c.CustomerAccounts)
                    {
                        var a = ca.Account;
                        Console.WriteLine($"       {a.AccountNumber,-12} {a.AccountType,-10} Balance: {a.CurrentBalance,12:F2}  {ca.OwnershipType,-8} {ca.AccountStatus,-8} @ {a.Branch?.Name}");
                    }
                }
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        static string ReadNonEmpty(string prompt)
        {
            string value;
            do
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("  [!] This field cannot be empty.");
            } while (string.IsNullOrEmpty(value));
            return value;
        }

        static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("  [!] Please enter a valid number.");
            }
        }

        static int ReadMenuChoice(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write($"{prompt}: ");
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"  [!] Please enter a number between {min} and {max}.");
            }
        }
    }
}
