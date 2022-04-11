using System;
using System.Collections.Generic;
using ElectroShop;

#nullable enable
namespace ElectroShopApi.Services
{
    public class OrderService
    {
        private static readonly HashSet<Order> Orders = new();
        private readonly CartService _cartService;
        private readonly PaymentService _paymentService;

        public OrderService(
            CartService cartService,
            PaymentService paymentService
        )
        {
            _cartService = cartService;
            _paymentService = paymentService;
        }

        public Order? GetOrder(Guid orderId)
        {
            return GetOrderUseCase.Get(Orders.Values(), orderId);
        }

        public List<Order> GetOrders(Guid userId)
        {
            return GetUserOrdersUseCase.Get(Orders.Values(), userId);
        }

        public Order CreateOrder(Guid cartId, PaymentOptionType paymentType)
        {
            var foundOrder = Orders.Values().Find(order => order.CartId == cartId);
            if (foundOrder != null)
            {
                return foundOrder;
            }

            var cart = _cartService.GetCart(cartId);
            if (cart == null)
            {
                throw new NullReferenceException();
            }

            var summary = GetCartSummaryUseCase.Get(cart);
            if (summary == null)
            {
                throw new NullReferenceException();
            }

            var payment = _paymentService.GetPayment(summary.GrossTotal, paymentType);
            var user = cart.User;
            var order = new Order(cart.Id, user, payment, Products: cart.Products);

            Orders.Add(order);
            return order;
        }
    }
}
