namespace BookStore.Models.ViewModel
{
    public class CategorysVM
    {
        public int Id { get; set; }
        public string name { get; set; } = null!;
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime updateDate { get; set; } = DateTime.Now;
    }
}
