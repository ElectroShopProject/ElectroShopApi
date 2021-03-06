using System;
using System.Collections.Generic;

#nullable enable
namespace ElectroShop
{
    public class GetCartUseCase
    {
        public static Cart? Get(List<Cart> carts, Guid id)
        {
            return carts.Find((Cart obj) => obj.Id == id);
        }
    }
}
