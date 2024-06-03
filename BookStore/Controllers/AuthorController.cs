using BookStore.Data;
using BookStore.Models;
using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext context;
        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Authors = context.Authors.ToList();
            var AuthorVMs = Authors.Select(author => new AuthorVM
            {
                Id = author.Id,
                Name = author.Name,
                CreatedDate = author.CreatedDate,
                UpdatedDate = author.UpdatedDate,
            }).ToList();

            return View(AuthorVMs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Author authorVM)
        {
            if (!ModelState.IsValid) {return View("Create", authorVM);}
            else
            {
                var author = new Author
                {
                    Name = authorVM.Name,
                    CreatedDate = authorVM.CreatedDate,
                    UpdatedDate = authorVM.UpdatedDate,
                };

                context.Authors.Add(author);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            if (!ModelState.IsValid) {return View("Create", author);}
            var ViewModel = new AuthorVMForm
            {
                Id = author.Id,
                Name = author.Name,
            };

            return View("Create", ViewModel);
        }
        [HttpPost]
        public IActionResult Edit(AuthorVMForm authorVM)
        {
            var auther = context.Authors.Find(authorVM.Id);
            if (!ModelState.IsValid) { return View("Create", authorVM); }
            if (authorVM == null) { return NotFound(); }
            auther.Name = authorVM.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            var author = context.Authors.Find(Id);
            if (author == null) { return NotFound(); }
            var viewModel = new AuthorVM
            {
                Id = author.Id,
                Name = author.Name,
                CreatedDate = author.CreatedDate,
                UpdatedDate = author.UpdatedDate,
            };
            return View("Details", viewModel);
        }
        public IActionResult Delete(int Id)
        {
            var author = context.Authors.Find(Id);
            if (author == null) { return NotFound(); }
            context.Authors.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
