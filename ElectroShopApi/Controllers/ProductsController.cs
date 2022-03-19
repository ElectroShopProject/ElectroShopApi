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
            new Product("Phone", Category: new ProductCategory("Telecommunication"))
        };


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductList;
        }
    }
}
