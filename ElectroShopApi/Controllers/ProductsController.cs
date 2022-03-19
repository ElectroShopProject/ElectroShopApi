using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShopApi.Controllers
{
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Printer", "Computer", "Phone"
        };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Summaries;
        }
    }
}
