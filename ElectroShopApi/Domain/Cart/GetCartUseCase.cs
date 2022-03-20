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

        public static Cart? Call(List<Cart> carts, Guid id)
        {
            return carts.Find((Cart obj) => obj.Id == id);
        }
    }
}
