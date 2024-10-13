using KickShop.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KickShop.Models
{
    public class Category
    {
        public Category()
        {
            CategoryId = Guid.NewGuid();
            Products = new HashSet<Product>();
        }
        [Comment("The Unique Identifier")]
        [Key]
        public Guid CategoryId { get; set; }
        [Comment("The Name Of The Category")]
        [Required]
        [MinLength(EntityValidationConstants.Category.NameMinLength)]
        [MaxLength(EntityValidationConstants.Category.NameMaxLength)]
        public string Name { get; set; }
        [Comment("Navigation Property for relateed products")]
        public HashSet<Product> Products { get; set; }
        [Comment("Image For The Category")]
        public string? ImageUrl { get; set; }
    }
}
