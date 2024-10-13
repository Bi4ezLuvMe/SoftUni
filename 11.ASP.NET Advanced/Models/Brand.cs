using KickShop.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KickShop.Models
{
    public class Brand
    {
        public Brand()
        {
            BrandId = Guid.NewGuid();
        }
        [Comment("The Unique Identifier")]
        [Key]
        public Guid BrandId { get; set; }
        [Comment("The Name Of The Brand")]
        [Required]
        [MinLength(EntityValidationConstants.Brand.NameMinLength)]
        [MaxLength(EntityValidationConstants.Brand.NameMaxLength)]
        public string Name { get; set; }
        [Comment("The Country Of Origin Of The The Brand")]
        [Required]
        [MinLength(EntityValidationConstants.Brand.CountryMinLength)]
        [MaxLength(EntityValidationConstants.Brand.CountryMaxLength)]
        public string Country { get; set; }
    }
}
