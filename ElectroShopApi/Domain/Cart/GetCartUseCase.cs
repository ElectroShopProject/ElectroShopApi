using System;
using System.Collections.Generic;

#nullable enable
namespace ElectroShopApi
{
    public class GetCartUseCase
    {
        public GetCartUseCase()
        {
        }

        public static CartSummary? Call(List<CartSummary> carts, Guid id)
        {
            return carts.Find((CartSummary obj) => obj.Id == id);
        }
    }
}
