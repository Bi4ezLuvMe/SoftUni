namespace DeskMarket.ViewModels
{
    public class ProductDetailsViewModel
    {
        public required int Id { get; set; }
        public string? ImageUrl { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public required string CategoryName { get; set; }
        public required string AddedOn { get; set; }
        public required string Seller { get; set; }
        public required bool HasBought { get; set; }
    }
}
