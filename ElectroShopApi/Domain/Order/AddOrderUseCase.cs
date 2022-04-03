using System;
using System.Collections.Generic;

namespace ElectroShopApi.Domain
{
    public class AddOrderUseCase
    {
        public static List<Order> Add(List<Order> orderList, Order order)
        {
            var result = new List<Order>();
            result.AddRange(orderList);
            result.Add(order);
            return result;
        }
    }
}
