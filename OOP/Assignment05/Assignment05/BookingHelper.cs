namespace Assignment05
{
    public static class BookingHelper
    {
        private static int bookingCounter = 0;

        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }

        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;
            if (numberOfTickets >= 5)
                total *= 0.9;
            return total;
        }

        public static void PrintAll(IPrintable[] items)
        {
            foreach (IPrintable item in items)
            {
                item.Print();
            }
        }
    }
}