using System;
using ElectroShop;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class ProductCategoryMapper
    {
        public static ProductCategory Map(ProductCategoryTable table)
        {
            return Enum.Parse<ProductCategory>(table.Name);
        }
    }
}
