using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
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
        private readonly ManufacturerTableContext _manufacturerContext;
        private readonly ProductCategoryTableContext _productContext;

        public ProductService(
            ProductTableContext context,
            TaxRateTableContext taxContext,
            ProductCategoryTableContext productContext,
            ManufacturerTableContext manufacturerContext)
        {
            _context = context;
            _taxContext = taxContext;
            _productContext = productContext;
            _manufacturerContext = manufacturerContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            var categorySource = await _productContext.ProductCategoryTable.ToListAsync();
            var manufacturerSource = await _manufacturerContext.ManufacturerTable.ToListAsync();
            var taxRateSource = await _taxContext.TaxRateTable.ToListAsync();
            return _context.ProductTable.Select(table => ProductMapper.Map(
                table,
                categorySource,
                manufacturerSource,
                taxRateSource)).ToList();
        }

        public async Task<Product?> GetProduct(Guid productId)
        {
            var products = await GetProducts();
            return GetProductUseCase.Get(products, productId);
        }
    }
}
