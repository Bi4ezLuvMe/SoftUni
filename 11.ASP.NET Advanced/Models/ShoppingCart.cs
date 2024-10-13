using KickShop.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KickShop.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartId = Guid.NewGuid();
            DateCreated = DateTime.Now.ToString(EntityValidationConstants.ShoppingCart.DateTimeFormat);
            CartItems = new List<CartItem>();
        }
        [Comment("The Unique Identifier")]
        [Key]
        public Guid ShoppingCartId { get; set; }
        [Comment("Foreign Key To The Customer Entity")]
        [Required]
        public string CustomerId { get; set; } = null!;
        [Comment("The Customer Who Created The Shopping Cart")]
        [Required]
        [ForeignKey("CustomerId")]
        public IdentityUser Customer { get; set; }
        [Comment("The Date When The Shopping Cart Was Created")]
        public string DateCreated { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
