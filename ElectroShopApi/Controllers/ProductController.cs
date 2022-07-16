using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace ElectroShopApi
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _service;

        public ProductController(ProductService service)
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

        // GET /products/categories
        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> GetProductsCategories()
        {
            try
            {
                var products = await _service.GetProductsCategories();
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
