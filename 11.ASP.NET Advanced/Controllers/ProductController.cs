using KickShop.Data;
using KickShop.Models;
using KickShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KickShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly KickShopDbContext context;
        public ProductController(KickShopDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IActionResult> Index()
        {
           List<Product>products = await context.Products.ToListAsync();
            return View(products);  
        }
        public async Task<IActionResult>Details(string id)
        {
            Guid GuidId;
            if(!Guid.TryParse(id,out GuidId))
            {
                return RedirectToAction(nameof(Index));
            }
            Product? product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == GuidId);

            if(product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                ProductId = GuidId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Quantity = product.StockQuantity,
                RelatedProducts = await context.Products.Where(x => x.CategoryId == product.CategoryId).ToListAsync()
            };

            return View(model);
        }
    }
}
