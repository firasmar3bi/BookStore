using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategorysController : Controller
    {
        private ApplicationDbContext context;

        public CategorysController(ApplicationDbContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {
            var category = context.Categorys.ToList();
            return View(category);
        }
    }
}
