using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public class AddProductToCartUseCase
    {

        public AddProductToCartUseCase()
        {
        }

        public static CartSummary Add(CartSummary cart, Product product)
        {
            var currentProducts = cart.Products;
            currentProducts.Add(product);
            return cart with { Products = currentProducts };
        }
    }
}
