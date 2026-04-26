public class IMAXTicket : Ticket
{
    public bool Is3D { get; set; }

    public IMAXTicket(int id, string movie, double price, bool is3D)
        : base(id, movie, price)
    {
        Is3D = is3D;
    }

    public override double CalculateFinalPrice()
    {
        double total = Price;
        if (Is3D) total += 20;
        return total * 1.09; // 9% IMAX surcharge
    }

    public override string ToString()
    {
        return $"[Ticket #{Id}] {MovieName} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }
}