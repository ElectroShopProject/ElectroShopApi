using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectroShop
{
    public class GetUserOrdersUseCase
    {
        public static List<Order> Get(List<Order> orders, Guid userId)
        {
            return orders.Where(order => order.User.Id == userId).ToList();
        }
    }
}
