namespace Assignment05
{
    public class Cinema
    {
        private Ticket[] tickets = new Ticket[20];
        private Projector projector = new Projector();

        public string CinemaName { get; set; }

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
        }

        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                    return tickets[index];
                return null;
            }
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("\n--- All Tickets ---");
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] != null)
                    tickets[i].Print();
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine($"=== {CinemaName} Opened ===");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine($"\n=== {CinemaName} Closed ===");
            projector.Stop();
        }
    }
}