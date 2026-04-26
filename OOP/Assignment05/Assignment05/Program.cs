namespace Assignment05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part01
            // Q1: What is an interface in C#? Why use it? 3 benefits?
            // interface is a contract, tells the class what methods to have but not how
            // we use it instead of concrete classes to make code more flexible
            // benefits:
            // 1- can swap implementations without breaking other code
            // 2- a class can implement multiple interfaces
            // 3- loose coupling, code depends on interface not a specific class

            // Q2:
            // a) both interfaces have Greet() so the class only writes one method and both share it
            //    we cant tell which Greet() belongs to which interface

            // b) fix it using explicit interface implementation:
            //    void IEnglishSpeaker.Greet() { Console.WriteLine("Hello"); }
            //    void IArabicSpeaker.Greet() { Console.WriteLine("Ahlan"); }
            //    this is called explicit interface implementation

            // c) no, cant call Greet() directly on Translator object because explicit implementation is not public
            //    to call each version we cast the object to the interface:
            //    ((IEnglishSpeaker)t).Greet();
            //    ((IArabicSpeaker)t).Greet();

            // Q3:
            // shallow copy: new object but reference fields still point to same objects as original
            // deep copy: new object and new copies of all reference fields, fully independent
            // use shallow when object has only value-type fields
            // use deep when object has reference fields and we want full independence
            // risk of shallow: changing a reference field in copy affects the original too

            // Q4:
            // output:
            // Dev - Testing
            // QA - Testing
            // Title is value type so e1.Title stays "Dev" and e2.Title becomes "QA"
            // Dept is reference type so both e1 and e2 point to same Department object
            // changing e2.Dept.Name affects e1.Dept.Name too
            #endregion
            #region Part02



            // a. Create Cinema and open it
            Cinema cinema = new Cinema("Grand Cinema");
            cinema.OpenCinema();

            // b. Create one of each ticket type and book them
            StandardTicket t1 = new StandardTicket("Inception", 80, "A5");
            VIPTicket t2 = new VIPTicket("Avengers", 200, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 100, true);

            t1.Book();
            t2.Book();
            t3.Book();

            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            // c. Print all tickets
            cinema.PrintAllTickets();

            // d. Clone VIP ticket and change movie name
            VIPTicket clone = (VIPTicket)t2.Clone();
            clone.MovieName = "Interstellar";

            Console.WriteLine("\n--- Clone Test ---");
            Console.Write("Original : "); t2.Print();
            Console.Write("Clone    : "); clone.Print();

            // e. Cancel one ticket and reprint
            t1.Cancel();
            Console.WriteLine("\n--- After Cancellation ---");
            t1.Print();

            // f. Use PrintAll utility
            Console.WriteLine("\n--- BookingHelper.PrintAll ---");
            BookingHelper.PrintAll(new IPrintable[] { t1, t2, t3 });

            // g. Close cinema
            cinema.CloseCinema();
        }
    }
}


#endregion




