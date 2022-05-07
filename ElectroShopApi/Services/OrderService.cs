using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Mappers;
using ElectroShopDB;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ElectroShopApi.Services
{
    public class OrderService
    {
        private readonly OrderTableContext _orderContext;
        private readonly OrderedProductTableContext _orderedProductsContext;
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly PaymentService _paymentService;

        public OrderService(
            CartService cartService,
            PaymentService paymentService,
            ProductService productService,
            OrderedProductTableContext orderedProductsContext,
            OrderTableContext orderContext,
            UserService userService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _productService = productService;
            _orderedProductsContext = orderedProductsContext;
            _orderContext = orderContext;
            _userService = userService;
        }

        public async Task<Order?> GetOrder(Guid orderId)
        {
            var orders = await GetOrders();
            return GetOrderUseCase.Get(orders, orderId);
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            var orders = await GetOrders();
            return GetUserOrdersUseCase.Get(orders, userId);
        }

        public async Task<List<Order>> GetOrders()
        {
            var users = await _userService.GetUsers();
            var payments = _paymentService.GetPayments();

            var orderTables = await _orderContext
                .OrderTable
                .ToListAsync();

            var orderedProductTables = await _orderedProductsContext
                .OrderedProductTable
                .ToListAsync();

            var productTables = await _productService.GetProducts();

            var orders = orderTables.Select(order => OrderMapper.Map(
                table: order,
                orderedProducts: orderedProductTables,
                users: users,
                payments: payments,
                products: productTables)).ToList();

            return orders;
        }

        public async Task<Order> CreateOrder(Guid cartId, PaymentOptionType paymentType)
        {
            var orders = await GetOrders();
            var foundOrder = orders.Find(order => order.CartId == cartId);

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


            var orderTable = OrderMapper.Map(order);
            var orderedProducts = orders
                .SelectMany(order => OrderedProductMapper.Map(order));

            await _orderContext.AddAsync(orderTable);
            await _orderedProductsContext.AddRangeAsync(orderedProducts);

            return order;
        }
    }
}
