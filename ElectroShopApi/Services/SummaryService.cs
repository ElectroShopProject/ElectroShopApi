using System;
using ElectroShopApi.Domain.Summary;
using ElectroShopApi.Services;

#nullable enable
namespace ElectroShopApi
{
    public class SummaryService
    {

        private readonly CartService _cartService;

        public SummaryService(CartService cartService)
        {
            _cartService = cartService;
        }

        public CartSummary? GetCartSummary(Guid cartId)
        {
            var cart = _cartService.GetCart(cartId);

            if (cart == null)
            {
                return null;
            }

            return GetCartSummaryUseCase.Get(cart);
        }
    }
}
