using System;
using System.Collections.Generic;

#nullable enable
namespace ElectroShop
{
    public class GetOrderUseCase
    {
        public static Order? Get(List<Order> orders, Guid orderId)
        {
            return orders.Find(order => order.Id == orderId);
        }
    }
}
