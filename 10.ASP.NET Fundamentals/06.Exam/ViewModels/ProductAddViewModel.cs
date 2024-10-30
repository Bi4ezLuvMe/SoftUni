using DeskMarket.Common;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = ModelConstants.Product.NameRequiredError)]
        [MinLength(ModelConstants.Product.NameMinLength, ErrorMessage = ModelConstants.Product.NameMinLengthError)]
        [MaxLength(ModelConstants.Product.NameMaxLength, ErrorMessage = ModelConstants.Product.NameMaxLengthError)]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = ModelConstants.Product.PriceRequiredError)]
        [Range(ModelConstants.Product.PriceMinRange, ModelConstants.Product.PriceMaxRange, ErrorMessage = "The Product Price Must Be Between {1} And {2}!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = ModelConstants.Product.DescriptionRequiredError)]
        [MinLength(ModelConstants.Product.DescriptionMinLength, ErrorMessage = ModelConstants.Product.DescriptionMinLengthError)]
        [MaxLength(ModelConstants.Product.DescriptionMaxLength, ErrorMessage = ModelConstants.Product.DescriptionMaxLengthError)]
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        [Required]
        public string AddedOn { get; set; } = null!;
        [Required(ErrorMessage = ModelConstants.Product.ProductCategoryError)]
        public int CategoryId { get; set; }
        public IList<ProductCategoriesViewModel> Categories { get; set; } = new List<ProductCategoriesViewModel>();
    }
}
