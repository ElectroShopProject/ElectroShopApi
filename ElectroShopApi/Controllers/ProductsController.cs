using Microsoft.AspNetCore.Mvc;
using ElectroShopApi.Services;
using System.Threading.Tasks;
using System;

namespace ElectroShopApi
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET /products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _service.GetProducts();
                return new JsonResult(products);
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
    }
}
