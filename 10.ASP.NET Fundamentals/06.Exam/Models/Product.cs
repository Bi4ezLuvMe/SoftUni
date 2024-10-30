using DeskMarket.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(ModelConstants.Product.NameMinLength)]
        [MaxLength(ModelConstants.Product.NameMaxLength)]
        public string ProductName { get; set; } = null!;
        [Required]
        [MinLength(ModelConstants.Product.DescriptionMinLength)]
        [MaxLength(ModelConstants.Product.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [Range(ModelConstants.Product.PriceMinRange,ModelConstants.Product.PriceMaxRange)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public string SellerId { get; set; } = null!;
        [Required]
        [ForeignKey("SellerId")]
        public IdentityUser Seller { get; set; } = null!;
        [Required]
        public DateTime AddedOn { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public IList<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }
}
