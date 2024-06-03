using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; } = null;
        public DateTime PublisherDate { get; set; }
        public string? ImgUrl { get; set; }
        public string Author { get; set; }
        public List<string> Categories { get; set; }

    }
}
