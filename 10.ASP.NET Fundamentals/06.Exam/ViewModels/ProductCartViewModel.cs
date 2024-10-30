namespace DeskMarket.ViewModels
{
    public class ProductCartViewModel
    {
        public required int Id { get; set; }
        public string? ImageUrl { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
    }
}
