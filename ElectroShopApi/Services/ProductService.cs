using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopApi.Mappers;
using ElectroShopDB;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ElectroShopApi
{
    public class ProductService
    {
        private readonly ProductTableContext _context;
        private readonly TaxRateTableContext _taxContext;
        private readonly ManufacturerTableContext _MantaxContext;

        public ProductService(ProductTableContext context, TaxRateTableContext taxContext, ManufacturerTableContext mantaxContext)
        {
            _context = context;
            _taxContext = taxContext;
            _MantaxContext = mantaxContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            var manufs = _MantaxContext.ManufacturerTable.ToList();

            // TODO There are tables
            Console.WriteLine("Count of manu = " + manufs.Count);

            var taxTables = await _taxContext.TaxRateTable.ToListAsync();
            var taxes = taxTables.Select(table => new TaxRate(
                Category: ProductCategoryMapper.Map(table.ProductCategoryTable),
                Percent: table.Percent
                )
            ).ToList();

            // TODO There are NOT tables
            Console.WriteLine("Count of taxes = " + taxTables.Count);

            // TODO Extract to mapper
            List<ProductTable> tables = await _context.ProductTable.ToListAsync();

            Console.WriteLine("Count of products = " + tables.Count);

            var products = tables.Select(table =>
                new Product(
                    Name: table.Name,
                    NetPrice: table.NetPrice,
                    GrossPrice: table.GrossPrice,
                    Category: Enum.Parse<ProductCategory>(table.ProductCategoryTable.Name),
                    TaxRate: taxes.Find(tax => Enum.GetName(tax.Category) == table.ProductCategoryTable.Name),
                    Manufacturer: new Manufacturer(
                        Name: table.ManufacturerTable.Name,
                        Country: table.ManufacturerTable.Country)
                    { Id = table.ManufacturerTable.Id.ToGuid() }
                )
                { Id = table.Id.ToGuid() }
            );

            foreach (var product in products)
            {
                // TODO There are NOT tables
                Console.WriteLine("Products = " + product.Name + " ");
            }

            return products.ToList();
        }

        public async Task<Product?> GetProduct(Guid productId)
        {
            // TODO Extract to UC
            var products = await GetProducts();
            return products.First(product => product.Id == productId);
        }
    }
}
