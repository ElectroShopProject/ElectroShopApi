using System.Collections.Generic;
using System.Linq;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class TaxRateMapper
    {
        public static TaxRate Map(TaxRateTable table, List<ProductCategoryTable> categoryTables)
        {
            var foundCategoryTable = categoryTables
                .First(category => category.Id == table.ProductCategoryId);

            var category = ProductCategoryMapper.Map(foundCategoryTable);

            return new TaxRate(Category: category, Percent: table.Percent) with { Id = table.Id.ToGuid() };
        }
    }
}
