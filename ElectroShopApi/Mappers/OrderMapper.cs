using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class OrderMapper
    {
        public static Order Map(
            OrderTable table,
            List<OrderedProductTable> orderedProducts,
            List<User> users,
            List<Payment> payments,
            List<Product> products)
        {
            var user = users.Find(user => user.Id == table.UserId.ToGuid());
            var payment = payments.Find(payment => payment.Id == table.PaymentId.ToGuid());
            var orderProducts = orderedProducts.Where(product => product.OrderId == table.Id);
            var foundProducts = orderProducts.Select(orderProduct => products.First(product => product.Id == orderProduct.ProductId.ToGuid())).ToList();

            return new Order(
                CartId: table.CartId.ToGuid(),
                User: user,
                Payment: payment,
                Products: foundProducts);
        }

        public static OrderTable Map(Order order)
        {
            return new OrderTable
            {
                Id = order.Id.ToString(),
                CartId = order.CartId.ToString(),
                UserId = order.User.Id.ToString(),
                PaymentId = order.Payment.Id.ToString()
            };
        }

        // TODO This logic should be on the frontend
        private static String GetOrderName(Order order)
        {
            if (order.Products.Count <= 0)
            {
                return $"Order No {order.Id}";
            }

            var productGroups = order.Products.GroupBy(product => product.Id);
            var firstGroup = productGroups.First();
            var count = firstGroup.Count();
            var name = firstGroup.First().Name;

            if (productGroups.Count() == 1)
            {
                return $"{count} x {name}";
            }

            return $"{count} x {name} and more";
        }
    }
}
