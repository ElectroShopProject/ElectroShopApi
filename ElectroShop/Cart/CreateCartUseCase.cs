﻿using System.Collections.Generic;

namespace ElectroShop
{
    public class CreateCartUseCase
    {
        public static Cart Create(List<Cart> carts, User user)
        {
            // Don't allow to create a new cart for the same user
            Cart cart = carts.Find((Cart obj) => obj.User == user);

            if (cart != null)
            {
                return cart;
            }

            return new Cart(User: user, Products: new List<Product>());
        }
    }
}
