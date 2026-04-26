public static class TicketExtensions
{
    public static string ToReceipt(this Ticket t)
    {
        return $"========== RECEIPT ==========\n" +
               $"Movie  : {t.MovieName}\n" +
               $"Type   : {t.GetType().Name}\n" +
               $"Price  : {t.Price}\n" +
               $"Final  : {t.CalculateFinalPrice():F2}\n" +
               $"Status : {(t.IsBooked ? "Booked" : "Not Booked")}\n" +
               $"=============================";
    }

    public static double TotalRevenue(this Ticket[] tickets)
    {
        double total = 0;
        foreach (Ticket t in tickets)
            total += t.CalculateFinalPrice();
        return total;
    }
}