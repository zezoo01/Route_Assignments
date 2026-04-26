namespace ReadMoreBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string? Title { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
