using System;
using ElectroShopApi.Domain.Payment;
using ElectroShopApi.Domain.Summary;
using ElectroShopApi.Services;

#nullable enable
namespace ElectroShopApi
{
    public class SummaryService
    {

        private readonly CartService _cartService;
        private readonly PaymentService _paymentService;

        public SummaryService(CartService cartService, PaymentService paymentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
        }

        public CartSummary? GetCartSummary(Guid cartId)
        {
            var cart = _cartService.GetCart(cartId);
            if (cart == null)
            {
                throw new NullReferenceException();
            }

            return GetCartSummaryUseCase.Get(cart);
        }

        public PaymentRequirment GetPaymentRequirment(Guid cartId)
        {
            var summary = GetCartSummary(cartId);
            if (summary == null)
            {
                throw new NullReferenceException();
            }

            var options = _paymentService.GetPaymentOptions();
            return GetPaymentRequirmentUseCase.Get(summary, options);
        }

        internal void FinalizeCart(Guid cartId)
        {
            var cart = _cartService.GetCart(cartId);
            if (cart == null)
            {
                throw new NullReferenceException();
            }

            var summary = GetCartSummary(cartId);
            if (summary == null)
            {
                throw new NullReferenceException();
            }

            var payment = _paymentService.GetPayment(summary.GrossTotal);
            var user = cart.User;
            var order = new Order(User: user, Payment: payment, Products: cart.Products);

            _cartService.DeleteCart(cartId);
        }
    }
}
