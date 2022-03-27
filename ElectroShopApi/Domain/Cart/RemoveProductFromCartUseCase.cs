using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public class RemoveProductFromCartUseCase
    {

        public RemoveProductFromCartUseCase()
        {
        }

        public static CartSummary Remove(CartSummary cart, Product product)
        {
            var currentProducts = cart.Products;
            currentProducts.Remove(product);
            return cart with { Products = currentProducts };
        }
    }
}
