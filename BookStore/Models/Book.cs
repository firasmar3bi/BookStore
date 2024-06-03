namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = null;
        public string Publisher { get; set; } = null;
        public DateTime PublisherDate { get; set; } 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; } = DateTime.Now;
        public string? ImgUrl { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
