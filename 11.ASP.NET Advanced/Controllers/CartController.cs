using KickShop.Data;
using KickShop.Models;
using KickShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KickShop.Controllers
{
    public class CartController : Controller
    {
        private readonly KickShopDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public CartController(KickShopDbContext _context,UserManager<IdentityUser>_userManager)
        {
            this.context = _context;
            this.userManager = _userManager;
        }
        public IActionResult Index()
        {
            var cart = GetUserCart();  // Assume this method gets the user's current cart

            // Map CartItems from the model to CartItemViewModel
            var cartItemsViewModel = cart.CartItems.Select(item => new CartItemViewModel
            {
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                Price = item.Product.Price,
                TotalPrice = item.Product.Price * item.Quantity,
                ImageUrl = item.Product.ImageUrl
            }).ToList();

            // Create the CartViewModel
            var cartViewModel = new CartViewModel
            {
                CartItems = cartItemsViewModel,
                CartTotal = cartItemsViewModel.Sum(i => i.TotalPrice)
            };

            return View(cartViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var cart = GetUserCart();
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                // Update quantity if the product is already in the cart
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add new cart item
                var newCartItem = new CartItem
                {
                    CartItemId = Guid.NewGuid(),
                    ProductId = productId,
                    Quantity = quantity,
                    ShoppingCartId = cart.ShoppingCartId
                };
                cart.CartItems.Add(newCartItem);
                await context.CartsItems.AddAsync(newCartItem);
            }

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        private ShoppingCart GetUserCart()
        {
            var userId = userManager.GetUserId(User); // Get the current user's ID
            var cart = context.ShoppingCarts.Include(c => c.CartItems)
                                      .ThenInclude(ci => ci.Product)
                                      .FirstOrDefault(c => c.CustomerId == userId);

            // If no cart exists for the user, create a new one
            if (cart == null)
            {
                cart = new ShoppingCart { CustomerId = userId };
                 context.ShoppingCarts.Add(cart);
                 context.SaveChanges();
            }

            return cart;
        }
        [HttpPost]
        public async Task<IActionResult>RemoveFromCart(string id)
        {
            Guid guidId;
            if(!Guid.TryParse(id,out guidId))
            {
                return RedirectToAction("Index", "Product");
            }
            ShoppingCart cart = await context.ShoppingCarts.FirstOrDefaultAsync(x => x.CustomerId == userManager.GetUserId(User));
            CartItem cartItem = await context.CartsItems.FirstOrDefaultAsync(x => x.ProductId == guidId && x.ShoppingCartId == cart.ShoppingCartId);
            if (cartItem is null)
            {
                return RedirectToAction("Index", "Product");
            }
            context.CartsItems.Remove(cartItem);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
