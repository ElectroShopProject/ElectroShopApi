using System;
using ElectroShopApi.Domain;

namespace ElectroShopApi.Services
{
    public class ProductService
    {

        private readonly Product CurrentProduct = new(
            Name: "Phone",
            Category: ProductCategory.Telecommunication,
            Manufacturer: new Manufacturer(Name: "ABC", Country: "Poland"),
            NetPrice: 100,
            GrossPrice: 123,
            TaxRate: TaxRate.DefaultTax
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
