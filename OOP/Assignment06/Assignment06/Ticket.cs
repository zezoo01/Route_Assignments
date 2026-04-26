public abstract class Ticket
{
    public int Id { get; set; }
    public string MovieName { get; set; }
    public double Price { get; set; }
    public bool IsBooked { get; private set; }

    protected Ticket(int id, string movie, double price)
    {
        Id = id;
        MovieName = movie;
        Price = price;
        IsBooked = false;
    }

    // Abstract: each ticket type must calculate its own final price
    public abstract double CalculateFinalPrice();

    // Virtual: default booking message, can be overridden
    public virtual void Book()
    {
        IsBooked = true;
        Console.WriteLine($"[Ticket #{Id}] {MovieName} has been booked.");
    }

    // Concrete: cancellation is the same for all types
    public void Cancel()
    {
        IsBooked = false;
        Console.WriteLine($"[Ticket #{Id}] {MovieName} booking cancelled.");
    }

    public override string ToString()
    {
        return $"[Ticket #{Id}] {MovieName} | {GetType().Name} | Price: {Price} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }
}