using KickShop.Data;
using KickShop.Models;
using KickShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KickShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly KickShopDbContext context;

        public HomeController(ILogger<HomeController> _logger,KickShopDbContext _context)
        {
            this.logger = _logger;
            this.context = _context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await context.Products.Take(3).ToListAsync();

            return View(products);
        }
    }
}
