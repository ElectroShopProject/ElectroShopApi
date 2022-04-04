using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public class AddProductToCartUseCase
    {
        public static Cart Add(Cart cart, Product product)
        {
            var currentProducts = cart.Products;
            currentProducts.Add(product);
            return cart with { Products = currentProducts };
        }
    }
}
