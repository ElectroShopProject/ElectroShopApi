using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Requests.Cart;
using ElectroShopApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

#nullable enable
namespace ElectroShopApi
{
    [Route("cart")]
    public class CartController : ControllerBase
    {

        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // POST /cart
        [HttpPost]
        public Cart Post([FromBody] CreateCartRequest request)
        {
            return _cartService.CreateCart(request.userId);
        }


        // GET /cart/id
        [HttpGet("{id}")]
        public Cart? Get(Guid id)
        {
            return _cartService.GetCart(id);
        }

        // POST /cart/products
        [Route("/products")]
        [HttpGet("{id}")]
        public List<Product> GetProducts(Guid id)
        {
            return _cartService.GetProducts(id);
        }

        // POST /cart/products/add
        [Route("/products/add")]
        [HttpPost]
        public Cart AddProduct([FromBody] AddProductToCartRequest request)
        {
            return _cartService.AddProduct(request.cartId, request.productId);
        }

        // POST /cart/products/remove
        [Route("/products/remove")]
        [HttpPost]
        public Cart RemoveProduct([FromBody] RemoveProductFromCartRequest request)
        {
            return _cartService.RemoveProduct(request.cartId, request.productId);
        }


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
