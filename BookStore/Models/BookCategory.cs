using System.Globalization;

namespace BookStore.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int CategoryId { get; set; }
        public Categorys? categorys { get; set; }
    }
}
