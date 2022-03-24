using System;
using ElectroShopApi.Domain;

namespace ElectroShopApi.Services
{
    public class ProductService
    {

        private readonly Product CurrentProduct = new(
            Name: "New product",
            Category: ProductCategory.Others
        );

        public ProductService()
        {
        }

        public Product GetProduct(Guid productId)
        {
            // In future allow more products to select
            return CurrentProduct;
        }
    }
}
