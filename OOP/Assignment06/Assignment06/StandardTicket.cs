public class StandardTicket : Ticket
{
    public string Seat { get; set; }

    public StandardTicket(int id, string movie, double price, string seat)
        : base(id, movie, price)
    {
        Seat = seat;
    }

    public override double CalculateFinalPrice()
    {
        return Price * 1.14; // 14% tax
    }

    public override string ToString()
    {
        return $"[Ticket #{Id}] {MovieName} | Standard | Seat: {Seat} | Price: {Price} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }
}