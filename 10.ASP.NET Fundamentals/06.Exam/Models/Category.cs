using DeskMarket.Common;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(ModelConstants.Category.NameMinLength)]
        [MaxLength(ModelConstants.Category.NameMaxLength)]
        public string Name { get; set; } = null!;
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}