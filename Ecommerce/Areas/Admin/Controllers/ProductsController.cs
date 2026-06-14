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
                .Select(product => new IndexProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Rate = product.Rate,
                    Quantity = product.Quantity,
                    CategoryName = product.Category.Name
                })
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

        public IActionResult Store(CreateProductViewModel request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
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
                .Select(product => new EditProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryId = product.CategoryId
                })
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

        public IActionResult Update(EditProductViewModel request)
        {
            var product = _context.Products.Find(request.Id);

            if (product is null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
