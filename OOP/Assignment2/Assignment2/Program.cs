using static Ticket;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part 01

            #region Q1
            //Q1 : Consider the following class:

            // A : Two problems with the design:
            // 1 - Owner and Balance are public fields => anyone can modify them directly 
            // 2 - Withdraw() has no validation => it allows negative balances with no checks.

            // B : 1 -  to fix it we can make Owner and Balance private fields and provide public properties to access them.
            //    2 - add validation inside Withdraw() => check if amount > 0 and amount <= Balance

            // c) Why public fields are bad in OOP:
            //Any code can change the data freely with no validation or control.
            #endregion

            #region Q2
            // private double radius = 5; => variable declared directly in a class. No control over access


            // Property: A wrapper around a field that uses get/ set to control access. like this:

            //  public double Area
            //  {
            //    get { return Math.PI * radius * radius; }

            //  }

            //A property can contain logic inside its get or set block.


            #endregion

            #region Q3
            //A - What is this[int index] ?
            // It's called an indexer. It allows objects to be accessed like arrays using [].
            // So you can write register[0] instead of calling a method.

            // B - What happens with register[10] = "Ali" ?
            // The array only has 5 slots (index 0–4),
            // so index 10 will throw an IndexOutOfRangeException (crash).

            // c - Can a class have more than one indexer? 
            // Yes — by using different parameter types.

            #endregion

            #region Q4
            // A- What does the `static` keyword mean on `TotalOrders`?
            // ,How is it different from the `Item` field ?
            // TotalOrders is static = shared between ALL objects (one copy only)
            // Item is normal = each object has its OWN copy

            // b- Can a static method inside `Order` access the `Item` field directly?
            // Why or why not?

            // Static method CANNOT access Item directly
            // because static has no "this" (no specific object)
            // must pass an object to access it
            #endregion

            #endregion

            #region part 02
            Cinema cinema = new Cinema();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nEnter data for Ticket {i + 1}");

                Console.Write("Movie Name: ");
                string movieName = Console.ReadLine();

                Console.Write("Ticket Type (0 = Standard, 1 = VIP, 2 = IMAX): ");
                TicketType type = (TicketType)int.Parse(Console.ReadLine());

                Console.Write("Seat Row: ");
                char row = char.Parse(Console.ReadLine());

                Console.Write("Seat Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                SeatLocation seat = new SeatLocation(row, number);
                Ticket ticket = new Ticket(movieName, type, seat, price);

                bool added = cinema.AddTicket(ticket);

                if (!added)
                {
                    Console.WriteLine("Cinema is full!");
                }
            }


            Console.WriteLine("\n===== All Tickets =====");

            for (int i = 0; i < 3; i++)
            {
                Ticket t = cinema[i];

                if (t != null)
                {
                    Console.WriteLine($"\nTicket ID : {t.TicketId}");
                    Console.WriteLine($"Movie     : {t.MovieName}");
                    Console.WriteLine($"Type      : {t.Type}");
                    Console.WriteLine($"Seat      : {t.Seat}");
                    Console.WriteLine($"Price     : {t.Price:F2}");
                    Console.WriteLine($"After Tax : {t.PriceAfterTax:F2}");
                }
            }


            Console.Write("\nEnter movie name to search: ");
            string searchName = Console.ReadLine();

            Ticket found = cinema.GetMovieByName(searchName);

            if (found != null)
            {
                Console.WriteLine("\nMovie Found:");
                Console.WriteLine($"Ticket ID : {found.TicketId}");
                Console.WriteLine($"Movie     : {found.MovieName}");
                Console.WriteLine($"Type      : {found.Type}");
                Console.WriteLine($"Seat      : {found.Seat}");
                Console.WriteLine($"Price     : {found.Price:F2}");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }


            Console.WriteLine($"\nTotal Tickets Sold: {Ticket.GetTotalTicketsSold()}");


            Console.WriteLine("\nBooking References:");
            Console.WriteLine(BookingHelper.GenerateBookingReference());
            Console.WriteLine(BookingHelper.GenerateBookingReference());


            double groupTotal = BookingHelper.CalcGroupDiscount(5, 80);
            Console.WriteLine($"\nGroup Discount (5 tickets × 80 EGP): {groupTotal:F2}");
            #endregion

        }
    }
}
