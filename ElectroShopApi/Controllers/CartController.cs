using System;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Requests.Cart;
using ElectroShopApi.Services;
using Microsoft.AspNetCore.Mvc;

#nullable enable
namespace ElectroShopApi
{
    [ApiController]
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
        public async Task<IActionResult> Post([FromBody] CreateCartRequest request)
        {
            return new JsonResult(await _cartService.CreateCart(request.UserId));
        }

        // GET /cart/id
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return new JsonResult(_cartService.GetCart(id));
        }

        // POST /cart/id/products
        [HttpGet("{id}/products")]
        public IActionResult GetProducts(Guid id)
        {
            return new JsonResult(_cartService.GetProducts(id));
        }

        // POST /cart/products/add
        [Route("products/add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductToCartRequest request)
        {
            try
            {
                Cart cart = await _cartService.AddProduct(
                    request.CartId,
                    request.ProductId
                );
                return new JsonResult(cart);
            }
            catch (NullReferenceException)
            {
                return new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        // POST /cart/products/remove
        [Route("products/remove")]
        [HttpPost]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductFromCartRequest request)
        {
            try
            {
                Cart cart = await _cartService.RemoveProduct(
                    request.cartId,
                    request.productId
                );
                return new JsonResult(cart);
            }
            catch (NullReferenceException)
            {
                return new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        // DELETE /cart/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var removed = _cartService.DeleteCart(id);
            return removed ? new OkResult() : new NotFoundResult();
        }
    }
}
