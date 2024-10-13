namespace KickShop.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal CartTotal { get; set; }

        public CartViewModel()
        {
            CartItems = new List<CartItemViewModel>();
        }
    }
}
