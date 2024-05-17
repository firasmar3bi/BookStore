using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Categorys
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string name { get; set; } = null!;

        public DateTime createDate { get; set; } = DateTime.Now;

        public DateTime updateDate { get; set; } = DateTime.Now;
 
    }
}
