namespace Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part01
            #region Q01
            //// Class Example 
            //// Both variables point to the same object (same reference)
            //PersonClass p1 = new PersonClass();
            //p1.Age = 20;
            //PersonClass p2 = p1; // copy reference
            //p2.Age = 30;
            //// p1 is affected because both refer to same memory
            //Console.WriteLine(p1.Age); // 30

            //// ===== Struct Example =====
            //// Each variable has its own copy (different values)
            //PersonStruct s1 = new PersonStruct();
            //s1.Age = 20;
            //PersonStruct s2 = s1; // copy value
            //s2.Age = 30;
            //// s1 is NOT affected
            //Console.WriteLine(s1.Age); // 20
            #endregion

            #region Q02
            //public string Name;      // can be accessed from outside
            //private int age;         // cannot be accessed directly from outside
            #endregion

            #region Q03
            // Step 1: Create a new Class Library project from Visual Studio
            // Step 2: Add classes and write your code inside the library
            // Step 3: Build the project to generate the DLL file
            // Step 4: Create or open another project (e.g., Console App)
            // Step 5: Add a reference to the Class Library
            // Step 6: Use the classes from the library inside your project
            #endregion

            #region Q04
            // A class library is a collection of classes and methods compiled into a DLL file
            // We use class libraries to:
            // - reuse code in multiple projects
            // - organize code in a clean way
            // - separate logic from main application
            // - make maintenance and updates easier
            #endregion

            #endregion
            #region Part02
            Console.Write("Enter Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
            TicketType type = (TicketType)int.Parse(Console.ReadLine());

            Console.Write("Enter Seat Row (A, B, C...): ");
            char row = char.Parse(Console.ReadLine());

            Console.Write("Enter Seat Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Amount: ");
            double discount = double.Parse(Console.ReadLine());

            Ticket t = new Ticket(name, type, new Seat(row, number), price);

            Console.WriteLine("\n===== Ticket Info =====");
            t.PrintTicket();
            Console.WriteLine($"Total (14% tax) : {t.CalcTotal(14):F2}");

            Console.WriteLine("\n===== After Discount =====");
            Console.WriteLine($"Discount Before : {discount:F2}");
            t.ApplyDiscount(ref discount);
            Console.WriteLine($"Discount After  : {discount:F2}");

            t.PrintTicket();
            #endregion
        }
    }


    //// Class Example
    //class PersonClass
    //{
    //    public int Age;
    //}
    //// struct Example
    //struct PersonStruct
    //{
    //    public int Age;
    //}


}
