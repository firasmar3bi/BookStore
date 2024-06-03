using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModel
{
    public class BookVMForm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = null;
        public string Publisher { get; set; } = null;
        public DateTime PublisherDate { get; set; }
        public IFormFile? ImgUrl { get; set; }


        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public List<SelectListItem>? Authors { get; set; }

        public List<int> SelectedCategories { get; set; } = new List<int>();
        public List<SelectListItem>? Categories { get; set; }
    }
}
