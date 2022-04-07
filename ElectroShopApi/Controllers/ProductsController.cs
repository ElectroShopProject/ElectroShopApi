using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ElectroShopApi.Domain;
using ElectroShopDB.Data;
using ElectroShopApi.Tables.Product;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using ElectroShopApi.Extensions;

namespace ElectroShopApi
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private readonly ManufacturerTableContext _context;

        public ProductsController(ManufacturerTableContext context)
        {
            _context = context;
        }

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

        // GET /products/manufacturers
        [Route("manufacturers")]
        [HttpGet]
        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            List<ManufacturerTable> tables = await _context.ManufacturerTable.ToListAsync();
            var manufacturers = tables.Select(table =>
                new Manufacturer(
                    Name: table.Name,
                    Country: table.Country
                )
                { Id = table.Id.ToGuid() }
            );

            return manufacturers;
        }
    }
}
