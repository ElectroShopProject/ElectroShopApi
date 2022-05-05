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
    }
}
