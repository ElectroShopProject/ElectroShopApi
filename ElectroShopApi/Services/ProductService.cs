using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopDB;

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
            List<ProductTable> tables = await _context.ProductTable.ToListAsync();
            var manufacturers = tables.Select(table =>
                new Product(
                    Name: table.Name,
                    Country: table.Country
                )
                { Id = table.Id.ToGuid() }
            );

            return manufacturers;
        }

        public Product GetProduct(Guid productId)
        {
            // In future allow more products to select
            return CurrentProduct;
        }
    }
}
