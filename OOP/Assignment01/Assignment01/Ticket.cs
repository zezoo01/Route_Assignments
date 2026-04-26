namespace Assignment01
{
    class Ticket
    {
        public string MovieName;
        public TicketType Type;
        public Seat Seat;
        private double Price;

        // Full constructor
        public Ticket(string movieName, TicketType type, Seat seat, double price)
        {
            Init(movieName, type, seat, price);
        }

        // Default constructor
        public Ticket(string movieName)
        {
            Init(movieName, TicketType.Standard, new Seat('A', 1), 50);
        }

        // Shared initialization
        private void Init(string movieName, TicketType type, Seat seat, double price)
        {
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        // Calculate total with tax (no change to original price)
        public double CalcTotal(double taxPercent)
        {
            return Price + (Price * taxPercent / 100);
        }

        // Apply discount
        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= Price)
            {
                Price -= discountAmount;
                discountAmount = 0;
            }
        }

        // Print ticket info
        public void PrintTicket()
        {
            Console.WriteLine($"Movie    : {MovieName}");
            Console.WriteLine($"Type     : {Type}");
            Console.WriteLine($"Seat     : {Seat.Row}{Seat.Number}");
            Console.WriteLine($"Price    : {Price:F2}");
        }
    }

}
