namespace ReadMoreBooks.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();



    }
}
