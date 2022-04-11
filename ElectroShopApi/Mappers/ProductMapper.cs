using System.Collections.Generic;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class ProductMapper
    {
        public static Product Map(
            ProductTable table,
            List<ProductCategoryTable> categoryTables,
            List<ManufacturerTable> manufacturerTables,
            List<TaxRateTable> taxRateTables)
        {
            var category = categoryTables
                .Find(category => category.Id == table.ProductCategoryId);

            var manufacturer = manufacturerTables
                .Find(manufacturer => manufacturer.Id == table.ManufacturerId);

            var taxRate = taxRateTables
                .Find(tax => tax.ProductCategoryId == table.ProductCategoryId);

            return new Product(
                Name: table.Name,
                NetPrice: table.NetPrice,
                GrossPrice: table.GrossPrice,
                Category: ProductCategoryMapper.Map(category),
                Manufacturer: ManufacturerMapper.Map(manufacturer),
                TaxRate: TaxRateMapper.Map(taxRate, categoryTables)
            )
            { Id = table.Id.ToGuid() };
        }
    }
}
