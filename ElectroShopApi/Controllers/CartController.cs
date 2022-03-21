using System;
using ElectroShopApi.Domain;
using ElectroShopApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// TODO Implement adding product to cart :)
namespace ElectroShopApi
{
    [Route("cart")]
    public class CartController : ControllerBase
    {

        private CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // POST /cart
        [HttpPost]
        public Cart Post(String Username)
        {

        }



        //// GET /cart/id
        //[HttpGet("{id}")]
        //public string Get(Guid id)
        //{
        //    // TODO Return cart
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    // TODO Implement
        //}

        //// PUT /cart/id
        //[HttpPut("{id}")]
        //public Cart Put()
        //{
        //    _cartService.AddProduct(new Product(
        //        Name: "New product",
        //        Category: ProductCategory.Others
        //    ));
        //    return _cartService.GetCart(Guid: Guid.NewGuid());
        //}

        //// DELETE /cart/id
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    // TODO Implement
        //}
    }
}
