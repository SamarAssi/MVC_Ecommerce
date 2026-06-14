using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers.User.Controllers;

[Area("User")]
public class HomeController : Controller
{
    ApplicationDbContext _context = new ApplicationDbContext();
    public IActionResult Index()
    {
        ViewBag.Categories = _context.Categories
            .AsNoTracking()
            .ToList();
        
        ViewBag.Products = _context.Products
            .AsNoTracking()
            .ToList();
        
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
