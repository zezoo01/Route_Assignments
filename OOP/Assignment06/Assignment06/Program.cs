namespace Assignment06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region part01
            // Q1:
            // Abstraction hides complexity and shows only what's necessary.
            // Encapsulation hides internal data and protects it using access modifiers.
            //
            // Real-world example: A Car
            // Abstraction => the driver only sees the steering wheel and pedals, not the engine internals.
            // Encapsulation => the engine parts are inside a closed hood; you can't directly touch the pistons.
            // The difference: abstraction is about hiding complexity in design,
            // encapsulation is about restricting direct access to data.

            // Q2:
            // Abstract Class vs Interface:
            // 1. Abstract class can have fields and constructors; interface cannot.
            // 2. Abstract class can have implemented methods; interface methods are all abstract by default (before C# 8).
            // 3. A class can inherit only one abstract class but implement multiple interfaces.
            // 4. Abstract class is used for "is-a" relationship; interface is for "can-do" capability.
            //
            // Choose abstract class when sharing common code/state between related classes.
            // Choose interface when defining a contract for unrelated classes.

            // Q3:
            // a) No, you can't write: Appliance a = new Appliance("LG");
            //    Because Appliance is abstract, it cannot be instantiated directly.
            //
            // b) PowerConsumption() is abstract => every subclass MUST provide its own version, no default makes sense.
            //    Status() is virtual => has a default value "Standby" but subclasses CAN override it.
            //    Label() is concrete => same logic for all appliances, no need to override.
            //
            // c) Calling Status() on a Toaster returns "Standby".
            //    Toaster did not override Status(), so it uses the base virtual implementation.

            // Q4:
            // a) A partial class splits one class across multiple files.
            //    The developer splits Calculator to separate concerns: core logic in one file, logging in another.
            //
            // b) A partial method is declared in one part and optionally implemented in another.
            //    If the implementation is deleted, the code still compiles.
            //    The compiler just removes the call to OnCalculated() silently — no error.
            //
            // c) An extension method adds methods to an existing type without modifying it.
            //    Three rules:
            //    1. Must be in a static class.
            //    2. Must be a static method.
            //    3. First parameter uses 'this' keyword followed by the type being extended.
            //
            // d) Output:
            //    Log: result = 20
            //    $20.00
            #endregion

            #region Part02
            Cinema cinema = new Cinema("CineMax");

            // a) Cannot create plain Ticket — it's abstract
            // Ticket t = new Ticket("Test", 100); // ERROR: Cannot create instance of abstract type 'Ticket'

            // b) Create one of each type and book them
            StandardTicket s = new StandardTicket(1, "Inception", 80, "A5");
            VIPTicket v = new VIPTicket(2, "Avengers", 200, true, 50);
            IMAXTicket im = new IMAXTicket(3, "Dune", 130, true);

            s.Book();
            v.Book();
            im.Book();
            Console.WriteLine();

            // c) Add to cinema and print all (via Cinema.Reporting)
            cinema.AddTicket(s);
            cinema.AddTicket(v);
            cinema.AddTicket(im);
            cinema.PrintAllTickets();

            // d) Polymorphism: loop through Ticket[] and call abstract method
            Console.WriteLine("--- Polymorphism: Final Price per Ticket ---");
            Ticket[] ticketArray = { s, v, im };
            foreach (Ticket t in ticketArray)
                Console.WriteLine($"{t.GetType().Name} => Final Price: {t.CalculateFinalPrice():F2}");
            Console.WriteLine();

            // e) Extension method: receipt
            Console.WriteLine("--- Extension Method: Receipt ---");
            Console.WriteLine(v.ToReceipt());
            Console.WriteLine();

            // f) Extension method: total revenue
            Console.WriteLine("--- Extension Method: Total Revenue ---");
            Console.WriteLine($"Total Revenue: {ticketArray.TotalRevenue():F2}");
            Console.WriteLine();

            // g) Close cinema
            cinema.Close();
            #endregion
        }
    }
}
