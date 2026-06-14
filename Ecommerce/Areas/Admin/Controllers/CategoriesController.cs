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
                .ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(Category request)
        {
            _context.Categories.Add(request);
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
                .FirstOrDefault(category => category.Id == id);

            if (category is null) 
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Update(Category request, int id) 
        {
            request.Id = id;

            _context.Categories.Update(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
