public class VIPTicket : Ticket
{
    public bool HasLounge { get; set; }
    public double LoungeServiceFee { get; set; }

    public VIPTicket(int id, string movie, double price, bool hasLounge, double fee)
        : base(id, movie, price)
    {
        HasLounge = hasLounge;
        LoungeServiceFee = fee;
    }

    public override double CalculateFinalPrice()
    {
        return (Price + LoungeServiceFee) * 1.15; // 15% VIP tax
    }

    public override string ToString()
    {
        return $"[Ticket #{Id}] {MovieName} | VIP | Lounge: {(HasLounge ? "Yes" : "No")} | Fee: {LoungeServiceFee} | Price: {Price} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }
}