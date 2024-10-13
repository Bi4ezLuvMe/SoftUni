using KickShop.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KickShop.Models
{
    public class CartItem
    {
        public CartItem()
        {
            CartItemId = Guid.NewGuid();
        }
        [Comment("The Unique Indentifier")]
        [Key]
        public Guid CartItemId { get; set; }
        [Comment("Foreign Key To The ShoppingCart Entity")]
        [Required]
        public Guid ShoppingCartId { get; set; }
        [Comment("The Shopping Cart")]
        [Required]
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; } = null!;
        [Comment("Foreign Key To The Product Entity")]
        [Required]
        public Guid ProductId { get; set; } 
        [Comment("The Product To Be Added")]
        [ForeignKey("ProductId")]
        [Required]
        public Product Product { get; set; } = null!;
        [Required]
        [Range(EntityValidationConstants.CartItem.QuantityRangeMin, EntityValidationConstants.CartItem.QuantityRangeMax)]
        public int Quantity { get; set; }
    }
}
