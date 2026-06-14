using Ecommerce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var products = _context.Products
                .Include(product => product.Category)
                .AsNoTracking()
                .ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories
                .AsNoTracking()
                .ToList();

            return View();
        }

        public IActionResult Store(Product request)
        {
            _context.Products.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .AsNoTracking()
                .FirstOrDefault(product => product.Id == id);

            ViewBag.Categories = _context.Categories
                .AsNoTracking()
                .ToList();

            if (product is null) 
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Update(Product request, int id) 
        {
            request.Id = id;

            _context.Products.Update(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
