using BookStore.Data;
using BookStore.Models;
using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext Contex;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BookController(ApplicationDbContext contex, IWebHostEnvironment webHostEnvironment)
        {
            Contex = contex;
            this.webHostEnvironment = webHostEnvironment;
        }

        // !-- Index Of Book Controller (Get Data For User) --! //
        public IActionResult Index()
        {
            var books = Contex.Books.
                Include(book =>book.Author).
                Include(book => book.Categories).
                ThenInclude(book => book.categorys).ToList();

            var bookVMs = books.Select(book => new BookVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Publisher = book.Publisher,
                PublisherDate = book.PublisherDate,
                ImgUrl = book.ImgUrl,
                Categories = book.Categories.Select(c => c.categorys.name).ToList(),
            }).ToList();
            
            return View("Index", bookVMs);
        }

        // !-- Create A Book (Get Data For Form) --! //
        [HttpGet]
        public IActionResult Create()
        {
            // !-- Get Author Select List --! //
            var authors = Contex.Authors.OrderBy(author => author.Name).ToList();

            var authorVMs = Contex.Authors
            .OrderBy(author => author.Name)
            .Select(author => new SelectListItem
            {
                Value = author.Id.ToString(),
                Text = author.Name
            }).ToList();

            // !-- Get Categories Select List --! //
            var categories = Contex.Categorys.OrderBy(category => category.name).ToList();
            var categoryVMs = Contex.Categorys
            .OrderBy(category => category.name)
            .Select(category => new SelectListItem
            {
                Value = category.Id.ToString(),
                Text = category.name
            }).ToList();

            var viewModel = new BookVMForm
            {
                Authors = authorVMs,
                Categories = categoryVMs
            };

            return View("Create", viewModel);
        }
        // !-- Create A Book (Seend Data To Data Base) --! //
        [HttpPost]
        public IActionResult Create(BookVMForm viewModel)
        {
            if ( !ModelState.IsValid) { return View("Create", viewModel); }
            // !-- Get Img File From User --! //
            string ImgeName = null;
            if(viewModel.ImgUrl != null)
            {
                ImgeName = Path.GetFileName(viewModel.ImgUrl.FileName);
                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/Img/Book", ImgeName);
                var stream = System.IO.File.Create(path);
                viewModel.ImgUrl.CopyTo(stream);
            }
            // !-- Convert From View Model To Model --! //
            var book = new Book
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Publisher = viewModel.Publisher,
                PublisherDate = viewModel.PublisherDate,
                AuthorId = viewModel.AuthorId,
                ImgUrl = ImgeName,
                Categories = viewModel.SelectedCategories.Select(id=>new BookCategory
                {
                    CategoryId = id,
                }).ToList(),
            };

            Contex.Books.Add(book);
            Contex.SaveChanges();
            return RedirectToAction("Index");
        }
        // !-- Delete Book From Data Base --!//
        public IActionResult Delete(int id)
        {
            var book = Contex.Books.Find(id);
            if (book == null) { return NotFound(); }

            if (book.ImgUrl != null) {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "Img/book", book.ImgUrl);
                if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
            }

            Contex.Books.Remove(book);
            Contex.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
