using Ecommerce;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

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
    }
}
