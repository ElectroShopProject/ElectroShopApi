using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

#nullable enable
namespace ElectroShopApi.Mappers
{
    public class OrderMapper
    {
        public static Order Map(
            OrderTable order,
            List<OrderedProductTable> orderedProducts,
            List<User> users,
            List<Payment> payments,
            List<Product> products)
        {
            var user = users.Find(user => user.Id == order.UserId.ToGuid());
            var payment = payments.Find(payment => payment.Id == order.PaymentId.ToGuid());
            var orderProducts = orderedProducts.Where(product => product.OrderId == order.Id);
            var foundProducts = orderProducts
                .SelectMany(orderProduct => GetProducts(products, orderProduct))
                .ToList();

            return new Order(
                CartId: order.CartId.ToGuid(),
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

        private static List<Product> GetProducts(List<Product> products, OrderedProductTable table)
        {
            List<Product> countedProducts = new();

            for (int i = 0; i < table.Quantity; i++)
            {
                countedProducts.Add(products.First(product => product.Id == table.ProductId.ToGuid()));
            }

            return countedProducts;
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
