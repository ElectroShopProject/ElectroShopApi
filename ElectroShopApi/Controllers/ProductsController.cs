using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ElectroShopApi.Domain;

namespace ElectroShopApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private static readonly Product[] ProductList = new[] {
            new Product(
                Name: "Phone",
                Category: ProductCategory.Telecommunication,
                Manufacturer: new Manufacturer(Name: "ABC", Country: "Poland"),
                NetPrice: 100,
                GrossPrice: 123,
                TaxRate: TaxRate.DefaultTax
            )
        };

        // GET /products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductList;
        }
    }
}
