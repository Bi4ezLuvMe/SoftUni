namespace DeskMarket.ViewModels
{
    public class ProductsAllViewModel
    {
        public required int Id { get; set; }
        public string? ImageUrl { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required bool IsSeller { get; set; }
        public required bool HasBought { get; set; }
    }
}
