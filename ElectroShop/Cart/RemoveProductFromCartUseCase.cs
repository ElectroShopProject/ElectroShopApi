namespace ElectroShop
{
    public class RemoveProductFromCartUseCase
    {
        public static Cart Remove(Cart cart, Product product)
        {
            var currentProducts = cart.Products;
            currentProducts.Remove(product);
            return cart with { Products = currentProducts };
        }
    }
}
