namespace Assignment03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            #region Q1
            //Q1 : Identify the type of relationship in each scenario below (Inheritance, Association, Aggregation, Composition, or Dependency):

            // A =) A University has Departments. If the university is closed,
            // the departments no longer exist. => Composition
            // B =) Driver uses a Car. The driver does not own the car. => Association
            // C =) A Dog is an Animal.=> Inheritance
            // D =) A Team has Players. If the team is deleted, the players still exist. => Aggregation
            // E =) A method receives a Logger as a parameter and calls it inside the method only. => Dependency
            #endregion

            #region Q2
            // Q2 : Answer the following questions about access modifiers and sealed:
            //a) A parent class has a protected field. Can a child class in a different assembly access it?
            //     yes , child class in a different assembly can access the protected field,
            //What about through an object instance from outside?
            //      cannot access it through an object instance from outside.
            //b) What is the difference between protected internal and private protected?
            //     protected internal : accessible within the same assembly and also in derived classes in other assemblies.
            //     private protected : accessible only within the same assembly and in derived classes within the same assembly.
            //c) What does the sealed keyword do when applied to a class?
            //     prevents a class from being inherited
            //What about when applied to a method?
            //     prevents a method from being overridden in derived classes.
            //d) Can you create an object from a sealed class using new? Why or why not?
            //     yes, because sealing a class only prevents it from being inherited, not from being instantiated.


            #endregion
            #endregion

            #region Part 02
            Cinema cinema = new Cinema("Grand Cinema");
            cinema.OpenCinema();

            // 2. Create one of each ticket type
            StandardTicket t1 = new StandardTicket("Inception", 120, "A-5");
            VIPTicket t2 = new VIPTicket("Avengers", 200, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 180, false);

            // 3. Add tickets to cinema
            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            // 4. Print all tickets
            cinema.PrintAllTickets();

            // 5. Statistics
            Console.WriteLine("\n========== Statistics ==========");
            Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");

            Console.WriteLine($"\nBooking Ref 1: {BookingHelper.GenerateBookingReference()}");
            Console.WriteLine($"Booking Ref 2: {BookingHelper.GenerateBookingReference()}");

            // 6. Close cinema
            cinema.CloseCinema();
            #endregion
        }
    }
}
