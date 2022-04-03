using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShopApi.Domain.User;

namespace ElectroShopApi
{
    public class GetUserOrdersUseCase
    {
        public GetUserOrdersUseCase()
        {
        }

        public static List<Order> Get(User user, List<Order> orders)
        {
            return orders.Where(order => order.User.Id == user.Id).ToList();
        }
    }
}
