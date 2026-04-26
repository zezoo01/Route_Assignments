public class Ticket
{
    private static int ticketCounter = 0;
    private decimal price;

    public string MovieName { get; set; }
    public int TicketId { get; }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (value > 0)
                price = value;
        }
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
    }

    public static int GetTotalTickets()
    {
        return ticketCounter;
    }
    public override string ToString()
    {
        return $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
    }
}