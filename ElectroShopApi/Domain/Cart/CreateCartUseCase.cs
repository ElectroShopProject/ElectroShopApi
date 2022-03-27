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

        public static CartSummary Create(List<CartSummary> carts, User user)
        {
            // Don't allow to create a new cart for the same user
            CartSummary cart = carts.Find((CartSummary obj) => obj.User == user);

            if (cart != null)
            {
                return cart;
            }

            return new CartSummary(User: user, Products: new List<Product>());
        }
    }
}
