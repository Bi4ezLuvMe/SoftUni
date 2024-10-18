﻿using KickShop.Models;

namespace KickShop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}