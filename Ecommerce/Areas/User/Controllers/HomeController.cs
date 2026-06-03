using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers.User.Controllers;

[Area("User")]
public class HomeController : Controller
{
    ApplicationDbContext _context = new ApplicationDbContext();
    public IActionResult Index()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Products = _context.Products.ToList();
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
