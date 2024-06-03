using BookStore.Data;
using BookStore.Models;
using BookStore.Models.ViewModel;
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

        // --! Create Categorys --! // 
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(CategorysVM categorysVM)
        {
            if (ModelState.IsValid)
            {
                var category = new Categorys
                {
                    name = categorysVM.name
                };
                context.Categorys.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", categorysVM);
            }
        }

        // --! Edit Categorys --! // 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categorys.Find(id);
            var viewModel = new CategorysVM
            {
                Id = category.Id,
                name = category.name,
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategorysVM categorysVM)
        {
            var category = context.Categorys.Find(categorysVM.Id);
            if (!ModelState.IsValid) {return View("Create", categorysVM);}
            if(category == null ) {return NotFound(); }
            category.name = categorysVM.name;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }
        // --! Details Catedorys --! //
        public IActionResult Details(int Id)
        {
            var category = context.Categorys.Find(Id);
            if (category == null) { return NotFound(); }
            var viewModel = new CategorysVM
            {
                Id = category.Id,
                name = category.name,
                createDate = category.createDate,
                updateDate = category.updateDate,
            };
            return View("Details", viewModel);
        }
        // --! Delete Categorys --!//
        public IActionResult Delete(int Id)
        {
            var category = context.Categorys.Find(Id);
            if (category == null) { return NotFound();}
            context.Categorys.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
