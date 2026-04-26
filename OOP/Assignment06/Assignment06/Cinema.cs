public partial class Cinema
{
    private List<Ticket> tickets = new List<Ticket>();
    public string Name { get; set; }

    public Cinema(string name)
    {
        Name = name;
        Console.WriteLine("=== Cinema Opened ===");
        Console.WriteLine("Projector ON\n");
    }

    public void AddTicket(Ticket t)
    {
        tickets.Add(t);
    }

    public void BookTicket(int id)
    {
        Ticket t = tickets.Find(x => x.Id == id);
        if (t != null) t.Book();
    }

    public void Close()
    {
        Console.WriteLine("Projector OFF");
        Console.WriteLine("=== Cinema Closed ===");
    }
}

public partial class Cinema
{
    public void PrintAllTickets()
    {
        Console.WriteLine("--- All Tickets (from Cinema.Reporting) ---");
        foreach (Ticket t in tickets)
            Console.WriteLine(t);
        Console.WriteLine();
    }

    public void PrintStats()
    {
        Console.WriteLine($"Total Tickets: {tickets.Count}");
        double revenue = 0;
        foreach (Ticket t in tickets)
            if (t.IsBooked) revenue += t.CalculateFinalPrice();
        Console.WriteLine($"Total Revenue: {revenue:F2}");
    }
}