

using KickShop.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KickShop.ViewModels
{
    public class ProductsPageViewModel
    {
        public List<Product>Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
