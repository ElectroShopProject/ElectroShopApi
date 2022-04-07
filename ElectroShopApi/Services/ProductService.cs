using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;
using Microsoft.EntityFrameworkCore;

namespace ElectroShopApi
{
    public class ProductService
    {

        private readonly ProductTableContext _context;

        public ProductService(ProductTableContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {

            // TODO Extract to mapper
            List<ProductTable> tables = await _context.ProductTable.ToListAsync();
            var manufacturers = tables.Select(table =>
                new Product(
                    Name: table.Name,
                    NetPrice: table.NetPrice,
                    GrossPrice: table.GrossPrice,
                    Category: Enum.Parse<ProductCategory>(table.ProductCategoryTable.Name),
                    TaxRate:
                    Manufacturer: new Manufacturer(
                        Name: table.ManufacturerTable.Name,
                        Country: table.ManufacturerTable.Country)
                    { Id = table.ManufacturerTable.Id.ToGuid() }
                )
                { Id = table.Id.ToGuid() }
            ); ;

            return manufacturers;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            // TODO Extract to UC
            var products = await GetProducts();
            return products.First(product => product.Id == productId);
        }
    }
}
