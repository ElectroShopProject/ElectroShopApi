using System.Collections.Generic;
using System.Linq;
using ElectroShop;
using ElectroShopDB;

namespace ElectroShopApi
{
    public static class OrderedProductMapper
    {
        public static List<OrderedProductTable> Map(Order order)
        {
            return order.Products
                .GroupBy(product => product.Id)
                .Select(group =>
                new OrderedProductTable
                {
                    OrderId = order.Id.ToString(),
                    ProductId = group.Key.ToString(),
                    Quantity = group.Count()
                }).ToList();
        }
    }
}
