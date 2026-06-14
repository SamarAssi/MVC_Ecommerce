using Ecommerce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = _context.Categories
                .AsNoTracking()
                .Select(category => new IndexCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                })
                .ToList();
                
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(CreateCategoryViewModel request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories
                .AsNoTracking()
                .Select(category => new EditCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                })
                .FirstOrDefault(category => category.Id == id);

            if (category is null) 
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Update(EditCategoryViewModel request) 
        {
            var category = _context.Categories.Find(request.Id);

            if (category is null)
            {
                return NotFound();
            }

            category.Name = request.Name;

            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
