using DeskMarket.Common;
using DeskMarket.Data;
using DeskMarket.Models;
using DeskMarket.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public ProductController(ApplicationDbContext _context,UserManager<IdentityUser>_userManager)
        {
            this.context = _context;
            this.userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await context.Products
            .Where(p => !p.IsDeleted)
            .ToListAsync();

          
            List<ProductsAllViewModel> models = new List<ProductsAllViewModel>();

            foreach (var product in products)
            {
                bool hasBought = await HasUserBoughtProduct(product.Id);

                models.Add(new ProductsAllViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    HasBought = hasBought,
                    IsSeller = product.SellerId == GetCurrentUserId()
                });
            }

            return View(models);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductAddViewModel model = new ProductAddViewModel();

            model.Categories = await PopulateCategories();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult>Add(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await PopulateCategories();

                return View(model);
            }

            Product product = new Product()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                AddedOn = DateTime.Parse(model.AddedOn),
                CategoryId = model.CategoryId,
                SellerId = GetCurrentUserId()
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            List<ProductCartViewModel> models = await context.ProductsClients
                .Include(pc=>pc.Product)
                .Where(pc => pc.ClientId == GetCurrentUserId()&&!pc.Product.IsDeleted)
                .Select(pc=>new ProductCartViewModel() 
                {
                    Id = pc.Product.Id,
                    ImageUrl = pc.Product.ImageUrl,
                    Price = pc.Product.Price,
                    ProductName = pc.Product.ProductName,
                })
                .ToListAsync();

            return View(models);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult>AddToCart(int id)
        {
            Product? product = await context.Products.FindAsync(id);

            if(product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductClient? productClient = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == GetCurrentUserId());

            if(productClient is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            productClient = new ProductClient()
            {
                ProductId = id,
                ClientId = GetCurrentUserId(),
            };

            await context.ProductsClients.AddAsync(productClient);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            Product? product = await context.Products.FirstOrDefaultAsync(p=>!p.IsDeleted&&p.Id == id);

            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if(product.SellerId != GetCurrentUserId())
            {
                return RedirectToAction(nameof(Index));
            }

            ProductEditViewModel model = new ProductEditViewModel();

            model.ProductName = product.ProductName;
            model.Price = product.Price;
            model.Description = product.Description;
            model.ImageUrl = product.ImageUrl;
            model.AddedOn = product.AddedOn.ToString(ModelConstants.Product.DateTimeFormat);
            model.CategoryId = product.CategoryId;
            model.SellerId = product.SellerId;
            model.Categories = await PopulateCategories();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult>Edit(ProductEditViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await PopulateCategories();

                return View(model);
            }

            Product? product = await context.Products.FindAsync(id);

            if(product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.AddedOn = DateTime.Parse(model.AddedOn);
            product.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = product.Id });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult>RemoveFromCart(int id)
        {
            ProductClient? pc = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == GetCurrentUserId());

            if(pc is null)
            {
                return RedirectToAction(nameof(Cart));
            }

            context.ProductsClients.Remove(pc);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }
        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            Product? product = await context.Products
                .Include(p=>p.Category)
                .Include(p=>p.Seller)
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if(product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                AddedOn = product.AddedOn.ToString(ModelConstants.Product.DateTimeFormat),
                CategoryName = product.Category.Name,
                Description = product.Description,
                HasBought = await HasUserBoughtProduct(id),
                ImageUrl = product.ImageUrl,
                Seller = product.Seller.UserName,
            };

            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            Product? product = await context.Products
                .Include(p=>p.Seller)
                .FirstOrDefaultAsync(p => !p.IsDeleted&&p.Id==id);

            if(product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if(product.SellerId != GetCurrentUserId())
            {
                return RedirectToAction(nameof(Index));
            }

            ProductDeleteViewModel model = new ProductDeleteViewModel()
            {
                Id = id,
                ProductName = product.ProductName,
                SellerId = product.SellerId,
                Seller = product.Seller.UserName,
            };

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult>Delete(ProductDeleteViewModel model)
        {
            Product? product = await context.Products.FindAsync(model.Id);

            if(product is null)
            {
                return RedirectToAction(nameof(Delete),new {id = model.Id });
            }

            product.IsDeleted = true;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private string GetCurrentUserId()
        {
            return userManager.GetUserId(User);
        }
        private async Task<List<ProductCategoriesViewModel>> PopulateCategories()
        {
            return await context.Categories
            .Select(c => new ProductCategoriesViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }
        private async Task<bool>HasUserBoughtProduct(int productId)
        {
            return await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ProductId == productId 
                &&
                pc.ClientId == GetCurrentUserId()) 
                == null ? false : true;
        }
    }
}