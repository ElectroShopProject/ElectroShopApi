using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Domain.User;

namespace ElectroShopApi
{
    public class CreateCartUseCase
    {
        public CreateCartUseCase()
        {

        }

        public static Cart Call(List<Cart> carts, User user)
        {
            return new Cart(Products: new List<Product>());
        }
    }
}
