namespace Assignment05
{
    public class Ticket : IPrintable, IBookable, ICloneable
    {
        private static int ticketCounter = 0;
        private decimal price;

        public int TicketId { get; }
        public string MovieName { get; set; }
        public bool IsBooked { get; private set; }

        public decimal Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }

        public decimal PriceAfterTax
        {
            get { return price + (price * 0.14m); }
        }

        public Ticket(string movieName, decimal price)
        {
            ticketCounter++;
            TicketId = ticketCounter;
            MovieName = movieName;
            Price = price;
            IsBooked = false;
        }

        public void Book()
        {
            if (IsBooked)
                Console.WriteLine("Ticket is already booked.");
            else
                IsBooked = true;
        }

        public void Cancel()
        {
            if (!IsBooked)
                Console.WriteLine("Ticket is not booked.");
            else
                IsBooked = false;
        }

        public void SetPrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public void SetPrice(decimal basePrice, decimal multiplier)
        {
            Price = basePrice * multiplier;
        }

        public static int GetTotalTickets()
        {
            return ticketCounter;
        }

        public static void ProcessTicket(Ticket t)
        {
            t.Print();
        }

        public virtual void Print()
        {
            Console.Write($"[Ticket #{TicketId}] {MovieName} | Price: {Price} | After Tax: {PriceAfterTax:F1} | Booked: {(IsBooked ? "Yes" : "No")}");
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}