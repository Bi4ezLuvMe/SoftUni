using KickShop.Common;
using KickShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KickShop.Models
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid();
        }
        [Comment("The Unique Identifier")]
        [Key]
        public Guid ProductId { get; set; }
        [Comment("The Product Name")]
        [Required]
        [MinLength(EntityValidationConstants.Product.NameMinLength)]
        [MaxLength(EntityValidationConstants.Product.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Comment("The Description For The Product")]
        [Required]
        [MinLength(EntityValidationConstants.Product.DescriptionMinLength)]
        [MaxLength(EntityValidationConstants.Product.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Comment("The Price Of The Product")]
        [Required]
        [Range(EntityValidationConstants.Product.PriceRangeMin, EntityValidationConstants.Product.PriceRangeMax)]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
        [Comment("Current Stock Quantity")]
        [Required]
        [Range(EntityValidationConstants.Product.QuantityRangeMin, EntityValidationConstants.Product.QuantityRangeMax)]
        public int StockQuantity { get; set; }
        [Comment("URL To The Product Image")]
        public string? ImageUrl { get; set; }
        [Comment("Foreign Key To The Category Entity")]
        [Required]
        public Guid CategoryId { get; set; }
        [Comment("The Category Of The Product")]
        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        [Comment("Foreign Key To The Brand Entity")]
        [Required]
        public Guid BrandId { get; set; }
        [Comment("The Brand Of The Product")]
        [Required]
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; } = null!;
        [Comment("The Size Of The Product")]
        [Required]
        public List<Sizes> Sizes { get; set; }
    }
}
